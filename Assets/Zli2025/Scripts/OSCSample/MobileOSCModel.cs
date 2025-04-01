using System.Collections.Generic;
using extOSC;
using UnityEngine;

namespace OSCSample
{
    public class MobileOSCModel : MonoBehaviour
    {
        [SerializeField] private OSCReceiver oscReceiver;
        [SerializeField] private List<float> receivedAudioData;
        
        public OSCReceiver OscReceiver       { get => oscReceiver; }
        public List<float> ReceivedAudioData { get => receivedAudioData; set => receivedAudioData = value; }
    }
}