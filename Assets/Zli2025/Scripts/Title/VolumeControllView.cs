using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class VolumeControllView : MonoBehaviour
    {
        [Header("出力")]
        [SerializeField] private Slider masterVolumeSlider;
        [SerializeField] private Slider bgmVolumeSlider;
        [SerializeField] private Slider seVolumeSlider;

        [Header("入力")]
        [SerializeField] private Slider micInputSlider;
        
        public float MasterVolumeSliderValue { get => masterVolumeSlider.value; set => masterVolumeSlider.value = value; }
        public float BGMVolumeSliderValue { get => bgmVolumeSlider.value; set => bgmVolumeSlider.value = value; }
        public float SEVolumeSliderValue { get => seVolumeSlider.value; set => seVolumeSlider.value = value; }
        
        public float MicInputSliderValue { get => micInputSlider.value; set => micInputSlider.value = value; }
    }
}