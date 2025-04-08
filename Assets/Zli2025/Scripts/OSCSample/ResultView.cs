using TMPro;
using UnityEngine;

namespace OSCSample
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private GameObject resultPanel;
        
        [SerializeField] private TextMeshProUGUI maxVolText;
        [SerializeField] private TextMeshProUGUI maxAltitudeText;
        
        public void ShowOrHideResultPanel(bool isShow)
        {
            if (isShow)
                resultPanel.SetActive(true);
            else
                resultPanel.SetActive(false);
        }
        
        public void SetScoreText(float maxVol, float maxAltitude)
        {
            maxVolText.text = "最大音量: " + maxVol.ToString("F2") + " dB";
            
            if(maxAltitude >= 6000)
                maxAltitudeText.text = "星となった---\n" + "そのうちあなたは考えるのをやめた";
            else
                maxAltitudeText.text = "最高高度: " + maxAltitude.ToString("F2") + " m";
        }
    }
}