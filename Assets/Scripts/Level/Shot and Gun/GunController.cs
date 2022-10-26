using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class GunController : MT_TestGameObject
    {
        void Start()
        {
            MessageBroker.Default
                .Receive<InputEvent>()
                .Where(x => x.Axis == app.model.input.fireAxis)
                .ThrottleFirst(TimeSpan.FromSeconds(app.model.gun.reloadTime))
                .Subscribe(x => Shoot()).AddTo(this);
        }

        private void Shoot()
        {
            if (!app.controller.level.IsGameActive())
                return;

            app.controller.shot.SetShotPosition(app.controller.shot.GetShot(), app.view.player.transform.position);
        }
    }
    
}