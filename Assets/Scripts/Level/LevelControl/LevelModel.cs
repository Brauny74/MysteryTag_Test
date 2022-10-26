using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class LevelModel : MT_TestGameObject
    {
        /// <summary>
        /// �K�p�{ �}�~���s�� �p�����u�����y�t���r �~�p�t�� ���~�y�������w�y����
        /// </summary>
        public int asteroidsAmountToDestroy;
        /// <summary>
        /// �K���|�|�p�z�t�u��, �{�����������z ���q���x�~�p���p�u�� �s���p�~�y���� �������r�~��
        /// </summary>
        public Collider levelBorder;
        /// <summary>
        /// true, �u���|�y �y�s���p �u���v �������t���|�w�p�u������, �����p�~���r�y������ false, �{���s�t�p �y�s���p �x�p�{�p�~���y�r�p�u������
        /// </summary>
        public bool gameActive = true;
    }
}