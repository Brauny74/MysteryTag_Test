using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class LevelController : MT_TestGameObject
    {
        private void Start()
        {
            MessageBroker.Default
                .Receive<AsteroidDestructionEvent>().Subscribe(_ => CountAsteroids()).AddTo(this);

            MessageBroker.Default
                .Receive<LevelEndEvent>().Subscribe(x => SetGameActive(false) ).AddTo(this);

            MessageBroker.Default
                .Publish(new AsteroidAmountEvent(app.model.level.asteroidsAmountToDestroy));
        }

        private void CountAsteroids()
        {
            app.model.level.asteroidsAmountToDestroy--;
            MessageBroker.Default
                .Publish(new AsteroidAmountEvent(app.model.level.asteroidsAmountToDestroy));
            if (app.model.level.asteroidsAmountToDestroy <= 0 && app.model.level.gameActive)
            {
                MessageBroker.Default
                    .Publish(new LevelEndEvent(true));
            }
        }

        private void SetGameActive(bool value)
        {
            app.model.level.gameActive = value;
        }

        public bool IsGameActive()
        {
            return app.model.level.gameActive;
        }

        public void SetUpLevel(LevelData levelData)
        {
            app.model.asteroid.minVelocity = levelData.MinAsteroidVelocity;
            app.model.asteroid.maxVelocity = levelData.MaxAsteroidVelocity;
            app.model.level.asteroidsAmountToDestroy = levelData.AsteroidsToDestroy;
        }

        public void SetUpLevel(LevelData levelData, GameSave gameSave)
        {
            StartCoroutine(DeferredSetUp(levelData, gameSave));            
        }

        private IEnumerator DeferredSetUp(LevelData levelData, GameSave gameSave)
        {
            yield return new WaitForSeconds(0.01f);
            app.model.asteroid.minVelocity = levelData.MinAsteroidVelocity;
            app.model.asteroid.maxVelocity = levelData.MaxAsteroidVelocity;
            app.model.level.asteroidsAmountToDestroy = gameSave.AsteroidsToDestroy;
            app.model.player.lives = gameSave.Lives;
            app.model.asteroid.generationPeriod = gameSave.AsteroidGenerationPeriod;
            for (int i = 0; i < gameSave.Asteroids.Count; i++)
            {
                app.controller.asteroid.SetAsteroid(gameSave.Asteroids[i]);
            }
            app.view.player.transform.position = new Vector3(gameSave.Player.X, 0, gameSave.Player.Z);
        }
    }
}