using System.Collections.Generic;
using extOSC;
using R3;
using UnityEngine;

namespace OSCSample
{
    public class MobileOSCModel : MonoBehaviour
    {
        [SerializeField] private OSCReceiver oscReceiver;
        
        private ReactiveProperty<bool> onReceiveComplete = new ReactiveProperty<bool>(false);

        private float timer;
        private float maxRecordingTime = 10f;
        private List<float> receivedDB = new List<float>();
        private float maxDB = 0f;
        
        public OSCReceiver OscReceiver       { get => oscReceiver; }
        
        public Observable<bool> OnReceiveComplete => onReceiveComplete.AsObservable();
        
        public float Timer                   { get => timer; set => timer = value; }
        public float MaxRecordingTime        { get => maxRecordingTime; set => maxRecordingTime = value; }
        public List<float> ReceivedAudioData { get => receivedDB; set => receivedDB = value; }
        public float MaxDB                   { get => maxDB; set => maxDB = value; }
        
        public void CheckRecordingTime()
        {
            if (timer >= maxRecordingTime)
            {
                onReceiveComplete.Value = true;
                timer = 0f;
            }
        }
    }
}