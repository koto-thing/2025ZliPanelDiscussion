using FMODUnity;
using General;
using UnityEngine;

namespace Title
{
    public class VolumeControllModel
    {
        private float currentMasterVolume;
        private float currentBGMVolume;
        private float currentSEVolume;

        private float currentMicInputVolume;
        
        private readonly string masterVolumePath = "vca:/Master";
        private readonly string bgmVolumePath = "vca:/BGM";
        private readonly string seVolumePath = "vca:/SE";
        
        private FMOD.Studio.VCA masterVCA;
        private FMOD.Studio.VCA bgmVCA;
        private FMOD.Studio.VCA seVCA;
        
        public float CurrentMasterVolume => currentMasterVolume;
        public float CurrentBGMVolume => currentBGMVolume;
        public float CurrentSEVolume => currentSEVolume;
        public float CurrentMicInputVolume => currentMicInputVolume;

        // @brief VCAを取得する
        public void GetVCAFromFMOD()
        {
            masterVCA = RuntimeManager.GetVCA(masterVolumePath);
            bgmVCA = RuntimeManager.GetVCA(bgmVolumePath);
            seVCA = RuntimeManager.GetVCA(seVolumePath);
        }

        // @brief MasterVCAのボリュームをセット
        public void SetMasterVolume(float volume)
        {
            currentMasterVolume = volume;
            VolumeGlobalVariable.MASTER_VOLUME = currentMasterVolume;
            masterVCA.setVolume(volume);
        }
        
        // @brief BGMVCAのボリュームをセット
        public void SetBGMVolume(float volume)
        {
            currentBGMVolume = volume;
            VolumeGlobalVariable.BGM_VOLUME = currentBGMVolume;
            bgmVCA.setVolume(volume);
        }
        
        // @brief SEVCAのボリュームをセット
        public void SetSEVolume(float volume)
        {
            currentSEVolume = volume;
            VolumeGlobalVariable.SE_VOLUME = currentSEVolume;
            seVCA.setVolume(volume);
        }

        public void SetMicInputVolume(float volume)
        {
            currentMicInputVolume = volume;
            VolumeGlobalVariable.MIC_INPUT_GAIN = currentMicInputVolume;
        }
    }
}