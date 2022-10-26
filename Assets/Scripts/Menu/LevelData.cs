using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Test/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        public string LevelName;

        public enum LevelState { Locked, Unlocked, Beaten }
        public LevelState CurrentLevelState;

        [Tooltip("True, „u„ƒ„|„y „…„‚„€„r„~„y „…„w„u „q„„|„y „ƒ„s„u„~„u„‚„y„‚„€„r„p„~„.")]
        public bool Generated;


        [Tooltip("„M„y„~„y„}„p„|„„~„p„‘ „ƒ„{„€„‚„€„ƒ„„„, „ƒ „{„€„„„€„‚„€„z „}„€„s„…„„ „ƒ„€„x„t„p„r„p„„„„ƒ„‘ „p„ƒ„„„u„‚„€„y„t„.")]
        public float MinAsteroidVelocity;
        [Tooltip("„M„p„{„ƒ„y„}„p„|„„~„p„‘ „ƒ„{„€„‚„€„ƒ„„„, „ƒ „{„€„„„€„‚„€„z „}„€„s„…„„ „ƒ„€„x„t„p„r„p„„„„ƒ„‘ „p„ƒ„„„u„‚„€„y„t„.")]
        public float MaxAsteroidVelocity;
        [Tooltip("„R„{„€„|„„{„€ „p„ƒ„„„u„‚„€„y„t„€„r „~„p„t„€ „…„~„y„‰„„„€„w„y„„„.")]
        public int AsteroidsToDestroy;
        [Tooltip("„R „{„p„{„€„z „„u„‚„y„€„t„y„‰„~„€„ƒ„„„„ („r „}„ƒ„{) „ƒ„€„x„t„p„„„„ƒ„‘ „p„ƒ„„„u„‚„€„y„t„.")]
        public float AsteroidsGenerationPeriod;

        public void GenerateRandomLevel(float minPossibleVelocity, float maxPossibleVelocity, int minAsteroidsToDestroy, int maxAsteroidsToDestroy, float minAsteroidGenerationPeriod, float maxAsteroidGenerationPeriod)
        {
            MinAsteroidVelocity = UnityEngine.Random.Range(minPossibleVelocity, maxPossibleVelocity - minPossibleVelocity);
            MaxAsteroidVelocity = UnityEngine.Random.Range(maxPossibleVelocity - minPossibleVelocity, maxPossibleVelocity);
            AsteroidsToDestroy = UnityEngine.Random.Range(minAsteroidsToDestroy, maxAsteroidsToDestroy);
            AsteroidsGenerationPeriod = UnityEngine.Random.Range(minAsteroidGenerationPeriod, maxAsteroidGenerationPeriod);
            Generated = true;
        }
    }
}