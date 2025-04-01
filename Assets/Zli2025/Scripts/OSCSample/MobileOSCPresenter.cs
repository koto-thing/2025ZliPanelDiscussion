using System.Collections.Generic;
using extOSC;
using OSCSample;
using UnityEngine;

namespace OSCSample
{
    
}
public class MobileOSCPresenter : MonoBehaviour
{
    [Header("依存関係")]
    [SerializeField] private MobileOSCModel model;
    [SerializeField] private MobileOSCView view;

    private void Start()
    {
        model.OscReceiver.Bind("/audio", ReceivedAudioData);
    }
    
    private void Update()
    {
        if (model.ReceivedAudioData.Count > 0)
        {
            foreach(var data in model.ReceivedAudioData)
            {
                Debug.Log(data);
            }
        }
    }

    private void ReceivedAudioData(OSCMessage message)
    {
        float sample = message.Values[0].FloatValue;
        model.ReceivedAudioData.Add(sample);
    }
}
