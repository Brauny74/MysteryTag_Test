using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Kazin_Test
{
    public class PlayerController : MT_TestGameObject
    {
        private void Start()
        {
            MessageBroker.Default.Receive<InputEvent>().Where(x => x.Axis == app.model.input.horizontalAxis).Subscribe(x => OnHorizontal(x.Direction)).AddTo(this);
            MessageBroker.Default.Receive<InputEvent>().Where(x => x.Axis == app.model.input.verticalAxis).Subscribe(x => OnVertical(x.Direction)).AddTo(this);
            MessageBroker.Default.Receive<PlayerHitEvent>().Subscribe(x => { GetHit(); } ).AddTo(this);

            MessageBroker.Default.Publish(new PlayerLivesEvent(app.model.player.lives));
        }


        public void OnHorizontal(float direction)
        {
            Vector3 currentPlayerPos = app.view.player.transform.position;

            Vector3 newDirectionVector = new Vector3(direction, 0, 0);                            
            app.view.player.Move(newDirectionVector, app.model.player.velocity);
            if (!app.model.level.levelBorder.bounds.Contains(app.view.player.transform.position))
            {
                app.view.player.transform.position = currentPlayerPos;
            }
        }

        public void OnVertical(float direction)
        {
            Vector3 currentPlayerPos = app.view.player.transform.position;

            Vector3 newDirectionVector = new Vector3(0, 0, direction);
            app.view.player.Move(newDirectionVector, app.model.player.velocity);
            if (!app.model.level.levelBorder.bounds.Contains(app.view.player.transform.position))
            {
                app.view.player.transform.position = currentPlayerPos;
            }
        }

        private void GetHit()
        {
            if (!app.controller.level.IsGameActive())
                return;

            app.model.player.lives -= 1;
            MessageBroker.Default
                .Publish(new PlayerLivesEvent(app.model.player.lives));
            if (app.model.player.lives <= 0)
            {
                MessageBroker.Default
                    .Publish(new LevelEndEvent(false));
            }
        }
    }
}