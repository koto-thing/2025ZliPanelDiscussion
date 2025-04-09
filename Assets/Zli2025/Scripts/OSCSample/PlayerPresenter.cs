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
        private EffectContModel effectContModel;
        private OSCSampleStateModel stateModel;
        private AudioControllerModel audioContModel;

        public PlayerPresenter(PlayerModel model, PlayerView view, EffectContModel effectContModel, MobileOSCModel oscModel, OSCSampleStateModel stateModel, AudioControllerModel audioContModel)
        {
            this.model = model;
            this.view = view;
            this.oscModel = oscModel;
            this.effectContModel = effectContModel;
            this.stateModel = stateModel;
            this.audioContModel = audioContModel;
            
            SetEvent();
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            if (stateModel.State == OSCSampleState.ANIMATION)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    model.ChangeJumpAvailable(true);  
                    effectContModel.IsPlayExplodeEffectValue = true;
                    audioContModel.ClickFeedbackSE.Play();
                    audioContModel.ExplodeEffectSE.Play();
                }
                
                if(!model.IsJumpAvailable)
                    view.ShowOrHideJumpReadyText(true);
                
                audioContModel.SetLowPassContParam(view.PlayerObject.transform.position.y);
            }
        }

        private void SetEvent()
        {
            model.OnJumpAvailable
                .Skip(1)
                .Subscribe(_ =>
                {
                    model.Jump(oscModel.MaxDB);
                    view.ShowOrHideJumpReadyText(false);
                    view.Jump(model.PlayerYPos, () => stateModel.State = OSCSampleState.GAMEOVER, () => audioContModel.TwinkleSE.Play());
                    audioContModel.JumpSE.Play();
                });
        }

        public void Dispose()
        {
            
        }
    }
}