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

        [Tooltip("True, �u���|�y �������r�~�y ���w�u �q���|�y ���s�u�~�u���y�����r�p�~��.")]
        public bool Generated;


        [Tooltip("�M�y�~�y�}�p�|���~�p�� ���{������������, �� �{�����������z �}���s���� �����x�t�p�r�p�������� �p�����u�����y�t��.")]
        public float MinAsteroidVelocity;
        [Tooltip("�M�p�{���y�}�p�|���~�p�� ���{������������, �� �{�����������z �}���s���� �����x�t�p�r�p�������� �p�����u�����y�t��.")]
        public float MaxAsteroidVelocity;
        [Tooltip("�R�{���|���{�� �p�����u�����y�t���r �~�p�t�� ���~�y�������w�y����.")]
        public int AsteroidsToDestroy;
        [Tooltip("�R �{�p�{���z ���u���y���t�y���~���������� (�r �}���{) �����x�t�p�������� �p�����u�����y�t��.")]
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