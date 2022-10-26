using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class ShotView : MT_TestGameObject
    {
        [SerializeField]
        private ParticleSystem shotParticles;

        [SerializeField]
        private ParticleSystem explosionParticles;

        [SerializeField]
        private float disappearanceTime;

        private bool IsDisappearing;

        private Rigidbody _rb;

        private void OnEnable()
        {
            shotParticles.gameObject.SetActive(true);
            explosionParticles.gameObject.SetActive(false);
            IsDisappearing = false;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            MessageBroker.Default.Receive<ShotMoveEvent>().Subscribe(x => Move(x.Direction, x.Velocity)).AddTo(this);
        }

        public void Move(Vector3 direction, float velocity)
        {
            if (IsDisappearing)
                return;

            _rb.MovePosition(Vector3.MoveTowards(transform.position, transform.position + direction, app.model.shot.velocity * Time.deltaTime));            
            MessageBroker.Default
                .Publish(new ShotOutOfBoundsEvent(this, transform.position));
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!IsDisappearing && collision.gameObject.CompareTag("Enemy"))
            {
                IsDisappearing = true;
                StartCoroutine(Disappear());
            }
        }

        private IEnumerator Disappear()
        {
            shotParticles.gameObject.SetActive(false);
            explosionParticles.gameObject.SetActive(true);
            yield return new WaitForSeconds(disappearanceTime);            
            MessageBroker.Default
                .Publish(new ShotHitEvent(this));
        }
    }
}