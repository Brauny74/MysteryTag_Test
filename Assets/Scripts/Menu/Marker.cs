using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Kazin_Test
{
    public class Marker : MonoBehaviour
    {
        public TMP_Text levelName;
        public Image markerImage;
        public LevelData levelToSelect;

        [Tooltip("�R�����p�z�� �����{���������s�� �������r�~��.")]
        public Sprite UnlockedLevelSprite;
        [Tooltip("�R�����p�z�� �������z�t�u�~�~���s�� �������r�~��.")]
        public Sprite BeatenLevelSprite;

        private void Start()
        {
            Init();
            if (levelToSelect.CurrentLevelState == LevelData.LevelState.Locked)
            {
                gameObject.SetActive(false);
            }
        }

        private void Init()
        {
            levelName.SetText(levelToSelect.LevelName);
            markerImage.sprite = GetLevelSprite(levelToSelect.CurrentLevelState); 
        }

        private Sprite GetLevelSprite(LevelData.LevelState state)
        {
            switch (state)
            {
                case LevelData.LevelState.Unlocked:
                    return UnlockedLevelSprite;
                case LevelData.LevelState.Beaten:
                    return BeatenLevelSprite;
                default:
                    return null;
            }
        }

        public void OnMarkerClick()
        {
            UniRx.MessageBroker.Default.Publish(new MarkerClickEvent(levelToSelect));
        }
    }
}