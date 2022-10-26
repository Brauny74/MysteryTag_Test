using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class AsteroidModel : MT_TestGameObject
    {
        public class AsteroidData
        {
            public float Velocity;
            public AsteroidView View;

            public AsteroidData(AsteroidView view, float velocity)
            {
                Velocity = velocity;
                View = view;
            }
        }

        List<AsteroidData> asteroids;

        [Tooltip("�P���x�y���y�� Z, �~�p �{�����������z �q���t���� �����x�t�p�r�p�������� �p�����u�����y�t��.")]
        public float origZ;
        [Tooltip("�^���� �}�y�~�y�}�p�|���~�p�� �����x�y���y�� �V �~�p �{�����������z �}���s���� �����x�t�p�r�p�������� �p�����u�����y�t��.")]
        public float minX;
        [Tooltip("�^���� �}�p�{���y�}�p�|���~�p�� �����x�y���y�� �V �~�p �{�����������z �}���s���� �����x�t�p�r�p�������� �p�����u�����y�t��.")]
        public float maxX;
        [Tooltip("�^���� �}�y�~�y�}�p�|���~�p�� ���{������������ �p�����u�����y�t�p.")]
        public float minVelocity;
        [Tooltip("�^���� �}�p�{���y�}�p�|���~�p�� ���{������������ �p�����u�����y�t�p.")]
        public float maxVelocity;
        [Tooltip("�^���� �r���u�}�� �r �}�y�|�|�y���u�{���~�t�p��, ���u���u�x �{�����������u �����x�t�p�������� �~���r���u �p�����u�����y�t��.")]
        public float generationPeriod;
        [Tooltip("�^���� �~�p�����p�r�|�u�~�y�u, �r �{�����������} �q���t���� �t�r�y�s�p�������� �p�����u�����y�t��.")]
        public Vector3 direction = new Vector3(0, 0, -1);

        private void Start()
        {
            asteroids = new List<AsteroidData>();
        }

        public void AddAsteroid(AsteroidView asteroid, float velocity)
        {
            asteroids.Add(new AsteroidData(asteroid, velocity));
        }

        public float GetAsteroidVelocity(AsteroidView asteroid)
        {
            foreach (AsteroidData a in asteroids)
            {
                if (asteroid == a.View)
                {
                    return a.Velocity;
                }
            }
            return 0;
        }

        public void SetAsteroidVelocity(AsteroidView asteroid, float Velocity)
        {
            foreach (AsteroidData a in asteroids)
            {
                if (asteroid == a.View)
                {
                    a.Velocity = Velocity;
                }
            }
        }
    }
}