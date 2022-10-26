using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class AsteroidController : MT_TestGameObject
    {
        Pooler asteroidsPool;
        List<AsteroidView> activeAsteroids;

        private void Awake()
        {
            asteroidsPool = GetComponent<Pooler>();
            activeAsteroids = new List<AsteroidView>();
        }

        private void Start()
        {
            var asteroidCreationStream = Observable.EveryUpdate()
                 .ThrottleFirst(TimeSpan.FromSeconds(app.model.asteroid.generationPeriod))
                 .Subscribe(_ => CreateAsteroid()).AddTo(this);

            MessageBroker.Default
                .Receive<AsteroidOutOfBoundsEvent>().Where(x => !app.model.level.levelBorder.bounds.Contains(x.CurrentPosition)).Subscribe(x => RemoveAsteroid(x.View)).AddTo(this);

            MessageBroker.Default
                .Receive<AsteroidDestructionFinishEvent>().Subscribe(x => RemoveAsteroid(x.View)).AddTo(this);
        }

        private void Update()
        {
            MessageBroker.Default
                .Publish(new AsteroidMoveEvent(app.model.asteroid.direction));
        }

        public void SetAsteroid(GameSave.AsteroidSave asteroid)
        {
            AsteroidView a = CreateAsteroid();
            a.transform.position = new Vector3(asteroid.X, 0, asteroid.Z);
            app.model.asteroid.SetAsteroidVelocity(a, asteroid.Velocity);
        }

        private AsteroidView CreateAsteroid()
        {
            if (!app.controller.level.IsGameActive())
                return null;
            AsteroidView a = asteroidsPool.GetPooledObject().GetComponent<AsteroidView>();
            a.SetPosition(GetNewAsteroidPosition());
            app.model.asteroid.AddAsteroid(a, GetRandomVelocity());
            activeAsteroids.Add(a);
            return a;
        }

        private Vector3 GetNewAsteroidPosition()
        {
            return new Vector3(UnityEngine.Random.Range(app.model.asteroid.minX, app.model.asteroid.maxX), 0, app.model.asteroid.origZ);
        }

        private float GetRandomVelocity()
        {
            return UnityEngine.Random.Range(app.model.asteroid.minVelocity, app.model.asteroid.maxVelocity);
        }

        private void RemoveAsteroid(AsteroidView asteroid)
        {
            asteroidsPool.ReturnToPool(asteroid.gameObject);
            activeAsteroids.Remove(asteroid);
        }

        public float GetAsteroidVelocity(AsteroidView a)
        {
            return app.model.asteroid.GetAsteroidVelocity(a);
        }
    }
}