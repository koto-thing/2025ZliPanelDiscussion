using System;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace OSCSample
{
    public class PlayerPresenter : IInitializable, ITickable, IDisposable
    {
        private PlayerModel model;
        private PlayerView view;
        private MobileOSCModel oscModel;
        private OSCSampleStateModel stateModel;

        public PlayerPresenter(PlayerModel model, PlayerView view, MobileOSCModel oscModel, OSCSampleStateModel stateModel)
        {
            this.model = model;
            this.view = view;
            this.oscModel = oscModel;
            this.stateModel = stateModel;
            
            SetEvent();
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            if (stateModel.State == OSCSampleState.GAMEPLAY)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    model.ChangeJumpAvailable(true);   
                }
            }
        }

        private void SetEvent()
        {
            model.OnJumpAvailable
                .Skip(1)
                .Subscribe(_ =>
                {
                    model.Jump(oscModel.MaxDB);
                    view.Jump(model.PlayerYPos);
                });
        }

        public void Dispose()
        {
            
        }
    }
}