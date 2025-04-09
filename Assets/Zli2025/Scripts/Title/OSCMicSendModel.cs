using extOSC;
using UnityEngine;

namespace Title
{
    public class OSCMicSendModel : MonoBehaviour
    {
        [SerializeField] private OSCTransmitter transmitter;
        [SerializeField] private string address = "/gain";
        
        private float micInputGain;

        public OSCTransmitter Transmitter => transmitter;
        public string Address => address;

        public float MicInputGain => micInputGain;

        // @brief マイク入力のゲインを取得する
        // @param マイク感度
        public void SetMicInputGain(float gain)
        {
            micInputGain = gain;
        }
    }
}