using System.Collections.Generic;
using System.Net;
using extOSC;
using R3;
using UnityEngine;

namespace OSCSample
{
    public class MobileOSCModel : MonoBehaviour
    {
        [SerializeField] private OSCReceiver oscReceiver;
        [SerializeField] private bool useMySelfAddress;
        
        private ReactiveProperty<float> currentRecievedData = new ReactiveProperty<float>();
        private ReactiveProperty<bool> onReceiveComplete = new ReactiveProperty<bool>(false);

        private float timer;
        private float maxRecordingTime = 10f;
        private List<float> receivedDB = new List<float>();
        private float maxDB = 0f;
        
        public OSCReceiver OscReceiver       { get => oscReceiver; }
        
        public Observable<float> CurrentRecievedData => currentRecievedData.AsObservable();
        public Observable<bool> OnReceiveComplete => onReceiveComplete.AsObservable();
        
        public float Timer                   { get => timer; set => timer = value; }
        public float MaxRecordingTime        { get => maxRecordingTime; set => maxRecordingTime = value; }
        public List<float> ReceivedAudioDataList { get => receivedDB; set => receivedDB = value; }
        public float MaxDB                   { get => maxDB; set => maxDB = value; }
        
        public void SetLocalHostIPAddress()
        {
            string hostName = Dns.GetHostName();
            string localHostIPAddress = null;
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);
            
            foreach(var address in addresses)
            {
                localHostIPAddress = address.ToString();
            }
            
            if (localHostIPAddress != null && !useMySelfAddress)
                oscReceiver.LocalHost = localHostIPAddress;
        }
        
        // @brief 受信した音声データを取得する
        public void ReceivedAudioData(OSCMessage message)
        {
            currentRecievedData.Value = message.Values[0].FloatValue;
            ReceivedAudioDataList.Add(currentRecievedData.Value);
        }
        
        // @brief 録音時間をチェックする
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