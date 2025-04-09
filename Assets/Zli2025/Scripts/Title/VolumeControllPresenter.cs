using System;
using General;
using VContainer.Unity;

namespace Title
{
    public class VolumeControllPresenter : IInitializable, ITickable, IDisposable
    {
        private VolumeControllModel model;
        private VolumeControllView view;

        public VolumeControllPresenter(VolumeControllModel model, VolumeControllView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Initialize()
        {
            model.GetVCAFromFMOD();
            view.MasterVolumeSliderValue = VolumeGlobalVariable.MASTER_VOLUME;
            view.BGMVolumeSliderValue = VolumeGlobalVariable.BGM_VOLUME;
            view.SEVolumeSliderValue = VolumeGlobalVariable.SE_VOLUME;
            view.MicInputSliderValue = VolumeGlobalVariable.MIC_INPUT_GAIN;
        }

        public void Tick()
        {
            model.SetMasterVolume(view.MasterVolumeSliderValue);
            model.SetBGMVolume(view.BGMVolumeSliderValue);
            model.SetSEVolume(view.SEVolumeSliderValue);
            model.SetMicInputVolume(view.MicInputSliderValue);
        }

        public void Dispose()
        {
            
        }
    }
}