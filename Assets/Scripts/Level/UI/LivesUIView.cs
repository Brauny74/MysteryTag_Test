using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using TMPro;

namespace Kazin_Test
{
    public class LivesUIView : MonoBehaviour
    {
        private TMP_Text UIText;

        private void Awake()
        {
            UIText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            MessageBroker.Default
                .Receive<PlayerLivesEvent>().Subscribe(x => SetLivesText(x.lives)).AddTo(this);
        }

        private void SetLivesText(int newLives)
        {
            UIText.SetText(newLives.ToString());
        }
    }
}