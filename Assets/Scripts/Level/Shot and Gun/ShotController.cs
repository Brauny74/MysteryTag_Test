using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class ShotController : MT_TestGameObject
    {
        private Pooler shotsPool;

        private void Awake()
        {
            shotsPool = GetComponent<Pooler>();
        }

        private void Start()
        {
            MessageBroker.Default
                .Receive<ShotOutOfBoundsEvent>().Where(x => !app.model.level.levelBorder.bounds.Contains(x.currentPosition)).Subscribe(x => RemoveShot(x.shotView)).AddTo(this);

            MessageBroker.Default
                .Receive<ShotHitEvent>().Subscribe(x => RemoveShot(x.shotView)).AddTo(this);
        }

        void FixedUpdate()
        {
            MessageBroker.Default
                .Publish(new ShotMoveEvent(app.model.shot.direction, app.model.shot.velocity));
        }

        public void SetShotPosition(ShotView shot, Vector3 position)
        {
            shot.transform.position = position;            
        }

        public ShotView GetShot()
        {
            return shotsPool.GetPooledObject().GetComponent<ShotView>();
        }

        public void RemoveShot(ShotView shot)
        {
            shotsPool.ReturnToPool(shot.gameObject);
        }
    }
}