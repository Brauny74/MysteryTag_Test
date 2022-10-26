using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class MT_TestGameObject : MonoBehaviour
    {
        protected TestApplication app
        {
            get
            {
                if (_app == null)
                {
                    _app = FindObjectOfType<TestApplication>();
                }
                return _app;
            }
        }

        private TestApplication _app;
    }
}