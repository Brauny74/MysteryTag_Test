using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class MenuInputController : MonoBehaviour
    {
        void Start()
        {
            var quitStream = Observable.EveryUpdate()
                 .Where(_ => Input.GetAxisRaw(GameModel.Instance.QuitAxis) != 0)
                 .Subscribe(_ => OnQuit()).AddTo(this);
        }

        private void OnQuit()
        {
            MessageBroker.Default.Publish(new QuitEvent());
        }
    }
}