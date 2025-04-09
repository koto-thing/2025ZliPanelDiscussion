using System;
using extOSC;
using VContainer.Unity;

namespace Title
{
    public class OSCMicSendPresenter : IInitializable, ITickable, IDisposable
    {
        private OSCMicSendModel model;
        private OSCMicSendView view;
        private VolumeControllModel volConModel;
        
        public OSCMicSendPresenter(OSCMicSendModel model, OSCMicSendView view, VolumeControllModel volConModel)
        {
            this.model = model;
            this.view = view;
            this.volConModel = volConModel;
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            model.SetMicInputGain(volConModel.CurrentMicInputVolume);
            
            var message = new OSCMessage(model.Address);
            message.AddValue(OSCValue.Float(model.MicInputGain));
            model.Transmitter.Send(message);
        }

        public void Dispose()
        {
            
        }
    }
}