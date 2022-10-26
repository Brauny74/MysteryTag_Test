using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    [Serializable]
    public class GameSave
    {
        public bool OnLevel;

        #region MenuData
        [Serializable]
        public class LevelSave
        {
            public string LevelName;

            public LevelData.LevelState CurrentLevelState;
            public bool Generated;
            public float MinAsteroidVelocity;
            public float MaxAsteroidVelocity;            
            public int AsteroidsToDestroy;            
            public float AsteroidsGenerationPeriod;
        }
        public List<LevelSave> Levels;
        #endregion


        #region LevelData
        [Serializable]
        public class PlayerSave
        {
            public float X;
            public float Z;

            public PlayerSave(float x, float z)
            {
                X = x;
                Z = z;
            }
        }

        [Serializable]
        public class AsteroidSave
        {
            public float X;
            public float Z;
            public float Velocity;

            public AsteroidSave(float x, float z, float velocity)
            {
                X = x;
                Z = z;
                Velocity = velocity;
            }
        }

        public int LevelIndex;
        public PlayerSave Player;
        public List<AsteroidSave> Asteroids;
        public int AsteroidsToDestroy;
        public int Lives;
        public float AsteroidGenerationPeriod;
        #endregion

        public GameSave()
        {
            Levels = new List<LevelSave>();
            Asteroids = new List<AsteroidSave>();
        }

        public void AddLevel(LevelData levelToAdd)
        {
            LevelSave l = new LevelSave();
            l.MinAsteroidVelocity = levelToAdd.MinAsteroidVelocity;
            l.MaxAsteroidVelocity = levelToAdd.MaxAsteroidVelocity;
            l.AsteroidsToDestroy = levelToAdd.AsteroidsToDestroy;
            l.AsteroidsGenerationPeriod = levelToAdd.AsteroidsGenerationPeriod;
            l.Generated = levelToAdd.Generated;
            l.CurrentLevelState = levelToAdd.CurrentLevelState;
            Levels.Add(l);
        }
    }
}