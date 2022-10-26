using System.IO;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System.Runtime.Serialization.Formatters.Binary;

namespace Kazin_Test
{
    public class GameController : Singleton<GameController>
    {
        private GameModel model;
        private TestApplication app;

        [SerializeField]
        private List<LevelData> levels;
        private LevelData currentLevel;

        private GameSave gameSave;
        private bool LoadingGame;

        private string savePath = "gameSave.txt";

        protected override void Awake()
        {
            base.Awake();
            model = FindObjectOfType<GameModel>();            
        }

        private void Start()
        {
            LoadingGame = false;
            LoadGame();

            for (int i = 0; i < levels.Count; i++)
            {
                if (!levels[i].Generated)
                {
                    levels[i].GenerateRandomLevel(model.MinPossibleVelocity, model.MaxPossibleVelocity, model.MinAsteroidsToDestroy, model.MaxAsteroidsToDestroy, model.MinAsteroidGenerationPeriod, model.MaxAsteroidGenerationPeriod);
                    levels[i].CurrentLevelState = LevelData.LevelState.Locked;
                }                
            }
            if (levels[0].CurrentLevelState != LevelData.LevelState.Beaten)
            {
                levels[0].CurrentLevelState = LevelData.LevelState.Unlocked;
            }

            MessageBroker.Default.Receive<MarkerClickEvent>().Subscribe(x => OnLevelMarkerClicked(x.levelToSelect)).AddTo(this);
            MessageBroker.Default.Receive<LevelEndEvent>().Where(x => x.Win).Subscribe(x => OnLevelBeaten(currentLevel)).AddTo(this);
            MessageBroker.Default.Receive<EndLevelButtonClickEvent>().Subscribe(_ => OnReturnToLevelSelect()).AddTo(this);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnLevelMarkerClicked(LevelData levelToSelect)
        {
            currentLevel = levelToSelect;
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        }

        private void OnReturnToLevelSelect()
        {
            SceneManager.LoadScene("LevelSelect");
        }

        private void OnLevelBeaten(LevelData levelToChange)
        {
            int i = levels.IndexOf(levelToChange);
            levels[i].CurrentLevelState = LevelData.LevelState.Beaten;
            if (i + 1 < levels.Count)
            {
                levels[i + 1].CurrentLevelState = LevelData.LevelState.Unlocked;
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            app = FindObjectOfType<TestApplication>();
            if (app != null)
            {
                SetUpLevel();
            }
        }

        private void SetUpLevel()
        {
            if (LoadingGame)
            {
                app.controller.level.SetUpLevel(currentLevel, gameSave);
            }
            else
            {
                app.controller.level.SetUpLevel(currentLevel);
            }
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void OnQuit()
        {
            Application.Quit();
        }

        private void SaveGame()
        {
            gameSave = new GameSave();
            if(app != null)
            {
                SaveOnLevel();
            }
            else
            {
                SaveOnMenu();
            }
            BinaryFormatter formatter = new BinaryFormatter();
            Stream fileStream = File.Open(savePath, FileMode.Create);

            formatter.Serialize(fileStream, gameSave);
            fileStream.Close();
        }

        private void SaveOnLevel()
        {
            if (app.controller.level.IsGameActive())
            {
                gameSave.OnLevel = true;
                gameSave.LevelIndex = levels.IndexOf(currentLevel);
                gameSave.Lives = app.model.player.lives;
                gameSave.AsteroidsToDestroy = app.model.level.asteroidsAmountToDestroy;
                gameSave.AsteroidGenerationPeriod = app.model.asteroid.generationPeriod;
                AsteroidView[] asteroidsToSave = FindObjectsOfType<AsteroidView>();
                foreach (AsteroidView a in asteroidsToSave)
                {
                    gameSave.Asteroids.Add(new GameSave.AsteroidSave(a.transform.position.x, a.transform.position.z, app.controller.asteroid.GetAsteroidVelocity(a)));
                }
                gameSave.Player = new GameSave.PlayerSave(app.view.player.transform.position.x, app.view.player.transform.position.z);
            }
            else
            {
                gameSave.OnLevel = false;                
            }
            SaveLevels();
        }

        private void SaveOnMenu()
        {
            gameSave.OnLevel = false;
            SaveLevels();
        }

        private void SaveLevels()
        {
            for (int i = 0; i < levels.Count; i++)
            {
                gameSave.AddLevel(levels[i]);
            }
        }

        private void LoadGame()
        {
            if (!File.Exists("gameSave.txt"))
                return;

            gameSave = new GameSave();
            BinaryFormatter formatter = new BinaryFormatter();
            Stream fileStream = File.Open(savePath, FileMode.Open);

            gameSave = (GameSave)formatter.Deserialize(fileStream);

            formatter.Serialize(fileStream, gameSave);
            fileStream.Close();
            if (gameSave.OnLevel)
            {
                LoadOnLevel();
            }
            else
            {
                LoadOnMenu();
            }
        }

        private void LoadOnLevel()
        {
            currentLevel = levels[gameSave.LevelIndex];
            LoadingGame = true;
            SceneManager.LoadScene("Level");
        }

        private void LoadOnMenu()
        {
            for (int i = 0; i < levels.Count; i++)
            {
                levels[i].Generated = gameSave.Levels[i].Generated;
                levels[i].AsteroidsGenerationPeriod = gameSave.Levels[i].AsteroidsGenerationPeriod;
                levels[i].AsteroidsToDestroy = gameSave.Levels[i].AsteroidsToDestroy;
                levels[i].MinAsteroidVelocity = gameSave.Levels[i].MinAsteroidVelocity;
                levels[i].MaxAsteroidVelocity = gameSave.Levels[i].MaxAsteroidVelocity;
                levels[i].CurrentLevelState = gameSave.Levels[i].CurrentLevelState;
            }
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}