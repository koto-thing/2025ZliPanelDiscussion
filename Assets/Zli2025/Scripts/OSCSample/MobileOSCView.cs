using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OSCSample
{
    public class MobileOSCView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI startDescText;
        [SerializeField] private TextMeshProUGUI youText;
        [SerializeField] private TextMeshProUGUI timerText;
        [SerializeField] private TextMeshProUGUI volumeText;
        
        [SerializeField] private Slider volumeSlider;
        
        public void ShowOrHideStartDescText(bool isShow)
        {
            if (isShow)
                startDescText.gameObject.SetActive(true);
            else
                startDescText.gameObject.SetActive(false);
        }
        
        public void ShowOrHideYouText(bool isShow)
        {
            if (isShow)
                youText.gameObject.SetActive(true);
            else
                youText.gameObject.SetActive(false);
        }
        
        public void ShowOrHideTimerText(bool isShow)
        {
            if (isShow)
                timerText.gameObject.SetActive(true);
            else
                timerText.gameObject.SetActive(false);
        }
        
        public void ShowOrHideVolumeText(bool isShow)
        {
            if (isShow)
                volumeText.gameObject.SetActive(true);
            else
                volumeText.gameObject.SetActive(false);
        }
        
        public void ShowOrHideVolumeSlider(bool isShow)
        {
            if (isShow)
                volumeSlider.gameObject.SetActive(true);
            else
                volumeSlider.gameObject.SetActive(false);
        }

        // @brief タイマーのテキストを更新する
        public void UpdateTimerText(float currentTime)
        {
            timerText.text = "残り時間：" + (10 - currentTime).ToString("F2") + "秒";
        }

        public void UpdateSliderValue(float value)
        {
            volumeSlider.value = value;
        }
    }
}