using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class AsteroidView : MT_TestGameObject
    {

        [SerializeField]
        private MeshRenderer asteroidMesh;

        [SerializeField]
        private ParticleSystem explosionParticles;

        [SerializeField]
        private float disappearanceTime;

        private bool IsDisappearing;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            asteroidMesh.gameObject.SetActive(true);
            explosionParticles.gameObject.SetActive(false);
        }

        private void Start()
        {
            MessageBroker.Default
                .Receive<AsteroidMoveEvent>()
                .Subscribe(x => Move(x.Direction, app.controller.asteroid.GetAsteroidVelocity(this))).AddTo(this);
        }

        public void SetPosition(Vector3 newPos)
        {
            transform.position = newPos;
        }

        public void Move(Vector3 direction, float velocity)
        {
            if (IsDisappearing)
                return;

            _rb.MovePosition(Vector3.MoveTowards(transform.position, transform.position + direction, app.model.shot.velocity * Time.deltaTime));
            MessageBroker.Default
                .Publish(new AsteroidOutOfBoundsEvent(this, transform.position));
        }

        private void OnTriggerEnter(Collider other)
        {
            ProcessCollision(other.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ProcessCollision(collision.gameObject);
        }

        private void ProcessCollision(GameObject other)
        {
            if (!IsDisappearing && (other.CompareTag("Projectile") || other.CompareTag("Player")))
            {
                MessageBroker.Default
                    .Publish(new AsteroidDestructionEvent(this));
                IsDisappearing = true;
                StartCoroutine(Disappear());
            }
        }

        private IEnumerator Disappear()
        {
            asteroidMesh.gameObject.SetActive(false);
            explosionParticles.gameObject.SetActive(true);
            yield return new WaitForSeconds(disappearanceTime);
            MessageBroker.Default
                .Publish(new AsteroidDestructionFinishEvent(this));
        }
    }
}