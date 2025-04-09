using FMODUnity;
using UnityEngine;

namespace OSCSample
{
    public class AudioControllerModel : MonoBehaviour
    {
        [Header("BGM")]
        [SerializeField] private StudioEventEmitter bgm;
        
        [Header("SE")]
        [SerializeField] private StudioEventEmitter clickFeedbackSE;
        [SerializeField] private StudioEventEmitter jumpSE;
        [SerializeField] private StudioEventEmitter chargeSE;
        [SerializeField] private StudioEventEmitter twinkleSE;
        [SerializeField] private StudioEventEmitter explodeEffectSE;
        
        public StudioEventEmitter BGM { get => bgm; set => bgm = value; }
        
        public StudioEventEmitter ClickFeedbackSE { get => clickFeedbackSE; set => clickFeedbackSE = value; }
        public StudioEventEmitter JumpSE          { get => jumpSE; set => jumpSE = value; }
        public StudioEventEmitter ChargeSE        { get => chargeSE; set => chargeSE = value; }
        public StudioEventEmitter TwinkleSE       { get => twinkleSE; set => twinkleSE = value; }
        public StudioEventEmitter ExplodeEffectSE { get => explodeEffectSE; set => explodeEffectSE = value; }

        // @brief BGMの音量を変更する
        // @param value 音量の値
        public void SetVolContParam(float value)
        {
            bgm.EventInstance.setParameterByName("VolContParam", value);
        }
        
        // @brief BGMのローパスフィルターのカットオフ周波数を変更する
        // @param currentPlayerYPos プレイヤーのY座標
        public void SetLowPassContParam(float currentPlayerYPos)
        {
            float newValue = 0f;
            
            if (currentPlayerYPos < 1000f && currentPlayerYPos >= 0f)
                newValue = 0.2f;
            else if (currentPlayerYPos < 2000f && currentPlayerYPos >= 1000f)
                newValue = 0.3f;
            else if(currentPlayerYPos < 3000f && currentPlayerYPos >= 2000f)
                newValue = 0.4f;
            else if(currentPlayerYPos < 4000f && currentPlayerYPos >= 3000f)
                newValue = 0.5f;
            else if(currentPlayerYPos < 5000f && currentPlayerYPos >= 4000f)
                newValue = 0.6f;
            else if(currentPlayerYPos < 6000f && currentPlayerYPos >= 5000f)
                newValue = 0.7f;
            else if (currentPlayerYPos >= 6000f)
                newValue = 0.8f;
            
            bgm.EventInstance.setParameterByName("LowPassContParam", newValue);
        }
    }
}
