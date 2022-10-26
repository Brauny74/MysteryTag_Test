using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using TMPro;

namespace Kazin_Test
{
    public class AsteroidsUIView : MonoBehaviour
    {
        private TMP_Text UIText;

        private void Awake()
        {
            UIText = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            MessageBroker.Default
                .Receive<AsteroidAmountEvent>().Subscribe(x => SetAsteroidsText(x.asteroidsAmount)).AddTo(this);
        }

        private void SetAsteroidsText(int newAsteroidsAmount)
        {
            UIText.SetText(newAsteroidsAmount.ToString());
        }
    }
}