using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class QuitUIButton : MonoBehaviour
    {
        public void OnClick()
        {
            UniRx.MessageBroker.Default.Publish(new QuitEvent());
        }
    }
}