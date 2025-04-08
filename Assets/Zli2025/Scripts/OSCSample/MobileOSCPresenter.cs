using System;
using extOSC;
using R3;
using UnityEngine;
using VContainer.Unity;

namespace OSCSample
{
    public class MobileOSCPresenter : IInitializable ,ITickable, IDisposable
    {
        private MobileOSCModel model;
        private MobileOSCView view;
        private OSCSampleStateModel stateModel;
        private AudioControllerModel audioContModel;
    
        public MobileOSCPresenter(MobileOSCModel model, MobileOSCView view, OSCSampleStateModel stateModel, AudioControllerModel audioContModel)
        {
            this.audioContModel = audioContModel;
            this.model = model;
            this.view = view;
            this.stateModel = stateModel;
            
            SetEvent();
        }

        public void Initialize()
        {
            model.SetLocalHostIPAddress();
            model.OscReceiver.Bind("/audio", model.ReceivedAudioData);
            view.ShowOrHideStartDescText(true);
            view.ShowOrHideYouText(true);
            view.ShowOrHideTimerText(false);
            view.ShowOrHideVolumeText(true);
            view.ShowOrHideVolumeSlider(true);
        }
    
        public void Tick()
        {
            // スペースキーを押して録音開始
            if (stateModel.State == OSCSampleState.WAITFORSTART)
            {
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    stateModel.State = OSCSampleState.RECORDING;
                    view.ShowOrHideStartDescText(false);
                    view.ShowOrHideYouText(false);
                    view.ShowOrHideTimerText(true);
                    view.ShowOrHideVolumeText(true);
                    view.ShowOrHideVolumeSlider(true);
                    audioContModel.SetVolContParam(0.4f);
                    audioContModel.ClickFeedbackSE.Play();
                    audioContModel.ChargeSE.Play();
                }
            }
            
            // 10秒間録音する
            if (model.ReceivedAudioDataList.Count > 0 && stateModel.State == OSCSampleState.RECORDING)
            {
                foreach(var data in model.ReceivedAudioDataList)
                {
                    if(data > model.MaxDB)
                    {
                        model.MaxDB = data;
                    }
                }
                
                model.CheckRecordingTime();
                view.UpdateTimerText(model.Timer);
                model.Timer += Time.deltaTime;
            }
        }
        
        private void SetEvent()
        {
            // 録音完了時の処理
            model.OnReceiveComplete
                .Skip(1)
                .Subscribe(_ =>
                {
                    view.ShowOrHideTimerText(false);
                    view.ShowOrHideVolumeText(false);
                    view.ShowOrHideVolumeSlider(false);
                    stateModel.State = OSCSampleState.ANIMATION;
                    audioContModel.SetVolContParam(0f);
                    audioContModel.ChargeSE.Stop();
                });
            
            // スライダーの値を更新する
            model.CurrentRecievedData
                .Skip(1)
                .Subscribe(data =>
                {
                    view.UpdateSliderValue(data);
                });
        }
        
        public void Dispose()
        {
            
        }
    }
}