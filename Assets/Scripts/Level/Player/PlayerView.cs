using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class PlayerView : MT_TestGameObject
    {
        public void Move(Vector3 direction, float velocity)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, velocity * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                MessageBroker.Default
                  .Publish(new PlayerHitEvent());
            }
        }
    }
}