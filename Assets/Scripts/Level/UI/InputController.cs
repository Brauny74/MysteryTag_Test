using UniRx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kazin_Test
{
    public class InputController : MT_TestGameObject
    {
        private CompositeDisposable _compositeDisposable;

        void Start()
        {
            _compositeDisposable = new CompositeDisposable();

            var horizontalStream = Observable.EveryUpdate()
                 .Where(_ => Input.GetAxisRaw(app.model.input.horizontalAxis) != 0)
                 .Select(axisDirection => Input.GetAxisRaw(app.model.input.horizontalAxis))
                 .Subscribe(axisDirection => OnHorizontal(axisDirection)).AddTo(_compositeDisposable);

            var verticalStream = Observable.EveryUpdate()
                 .Where(_ => Input.GetAxisRaw(app.model.input.verticalAxis) != 0)
                 .Select(axisDirection => Input.GetAxisRaw(app.model.input.verticalAxis))
                 .Subscribe(axisDirection => OnVertical(axisDirection)).AddTo(_compositeDisposable);

            var fireStream = Observable.EveryUpdate()
                 .Where(_ => Input.GetAxisRaw(app.model.input.fireAxis) != 0)
                 .Select(axisDirection => Input.GetAxisRaw(app.model.input.fireAxis))
                 .Subscribe(_ => OnFire()).AddTo(_compositeDisposable);

            var quitStream = Observable.EveryUpdate()
                 .Where(_ => Input.GetAxisRaw(GameModel.Instance.QuitAxis) != 0)
                 .Subscribe(_ => OnQuit()).AddTo(this);
        }

        private void OnHorizontal(float direction)
        {
            if (!app.controller.level.IsGameActive())
                return;

            MessageBroker.Default
                .Publish(new InputEvent(app.model.input.horizontalAxis, direction));
        }

        private void OnVertical(float direction)
        {
            if (!app.controller.level.IsGameActive())
                return;

            MessageBroker.Default
                  .Publish(new InputEvent(app.model.input.verticalAxis, direction));
        }

        private void OnFire()
        {
            if (!app.controller.level.IsGameActive())
                return;

            MessageBroker.Default
                  .Publish(new InputEvent(app.model.input.fireAxis));
        }

        private void OnQuit()
        {
            MessageBroker.Default.Publish(new QuitEvent());
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
        }
        
    }    
}