using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Kazin_Test
{
    public class UILossWindow : MonoBehaviour
    {
        public RectTransform panel;

        private void Start()
        {
            panel.gameObject.SetActive(false);
            MessageBroker.Default
                .Receive<LevelEndEvent>().Where(x => !x.Win).Subscribe(x => ShowPanel()).AddTo(this);
        }

        private void ShowPanel()
        {
            panel.gameObject.SetActive(true);
        }

        public void OnButtonClick()
        {
            MessageBroker.Default.Publish(new EndLevelButtonClickEvent());
        }
    }
}