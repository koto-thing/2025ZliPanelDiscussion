using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class TitleButtonsView : MonoBehaviour
    {
        [SerializeField] private Button startButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private Button quitButton;
        
        public Button StartButton => startButton;
        public Button CreditButton => creditButton;
        public Button QuitButton => quitButton;
    }
}