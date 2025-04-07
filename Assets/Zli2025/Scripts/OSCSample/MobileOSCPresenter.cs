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
    
        public MobileOSCPresenter(MobileOSCModel model, MobileOSCView view, OSCSampleStateModel stateModel)
        {
            this.model = model;
            this.view = view;
            this.stateModel = stateModel;
            
            SetEvent();
        }

        public void Initialize()
        {
            stateModel.State = OSCSampleState.RECORDING;
            model.OscReceiver.Bind("/audio", ReceivedAudioData);
        }
    
        public void Tick()
        {
            if (model.ReceivedAudioData.Count > 0 && stateModel.State == OSCSampleState.RECORDING)
            {
                foreach(var data in model.ReceivedAudioData)
                {
                    if(data > model.MaxDB)
                    {
                        model.MaxDB = data;
                    }
                }
                
                Debug.Log(stateModel.State);
                model.CheckRecordingTime();
                model.Timer += Time.deltaTime;
            }
        }
        
        private void SetEvent()
        {
            model.OnReceiveComplete
                .Skip(1)
                .Subscribe(_ =>
                {
                    stateModel.State = OSCSampleState.GAMEPLAY;
                });
        }

        private void ReceivedAudioData(OSCMessage message)
        {
            float sample = message.Values[0].FloatValue;
            model.ReceivedAudioData.Add(sample);
        }

        public void Dispose()
        {
            
        }
    }
}