using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class GameModel : Singleton<GameModel>
    {
        [Tooltip("�M�y�~�y�}�p�|���~�p�� ���{������������ �p�����u�����y�t���r, �{���������p�� �}���w�u�� �q������ �~�p�x�~�p���u�~�p �~�p �������r�~�u.")]
        public float MinPossibleVelocity;
        [Tooltip("�M�p�{���y�}�p�|���~�p�� ���{������������ �p�����u�����y�t���r, �{���������p�� �}���w�u�� �q������ �~�p�x�~�p���u�~�p �~�p �������r�~�u.")]
        public float MaxPossibleVelocity;
        [Tooltip("�M�y�~�y�}�p�|���~���u �{���|�y���u�����r�� �p�����u�����y�t���r, �{�����������u �}���w�u�� �q������ ���������p�r�|�u�~�� �t�|�� ���~�y�������w�u�~�y�� �~�p �������r�~�u.")]
        public int MinAsteroidsToDestroy;
        [Tooltip("�M�p�{���y�}�p�|���~���u �{���|�y���u�����r�� �p�����u�����y�t���r, �{�����������u �}���w�u�� �q������ ���������p�r�|�u�~�� �t�|�� ���~�y�������w�u�~�y�� �~�p �������r�~�u.")]
        public int MaxAsteroidsToDestroy;
        [Tooltip("�M�y�~�y�}�p�|���~���z ���u���y���t, �� �{�����������} �����x�t�p�������� �p�����u�����y�t�� �~�p �������r�~����.")]
        public float MinAsteroidGenerationPeriod;
        [Tooltip("�M�p�{���y�}�p�|���~���z ���u���y���t, �� �{�����������} �����x�t�p�������� �p�����u�����y�t�� �~�p �������r�~����.")]
        public float MaxAsteroidGenerationPeriod;
        public string QuitAxis = "Cancel";
    }
}