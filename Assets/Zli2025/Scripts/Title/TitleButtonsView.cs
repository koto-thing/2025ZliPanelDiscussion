using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Title
{
    public class TitleButtonsView : MonoBehaviour
    {
        [Header("ボタン")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button optionButton;
        [SerializeField] private Button creditButton;
        [SerializeField] private Button quitButton;

        [Header("パネル")] 
        [SerializeField] private GameObject optionPanel;
        [SerializeField] private GameObject creditPanel;
        [SerializeField] private GameObject quitPanel;

        [Header("クレジットパネルのボタン")] 
        [SerializeField] private Button optionCloseButton;
        [SerializeField] private Button creditCloseButton;

        [Header("ゲーム終了の確認画面のボタン")]
        [SerializeField] private Button quitAcceptButton;
        [SerializeField] private Button quitCloseButton;
        
        public Button StartButton => startButton;
        public Button OptionButton => optionButton;
        public Button CreditButton => creditButton;
        public Button QuitButton => quitButton;
        public Button OptionCloseButton => optionCloseButton;
        public Button CreditCloseButton => creditCloseButton;
        public Button QuitAcceptButton => quitAcceptButton;
        public Button QuitCloseButton => quitCloseButton;

        // @brief オプションパネルを表示 or 非表示にする
        public void ShowOrHideOptionPanel()
        {
            optionPanel.SetActive(!optionPanel.activeSelf);
        }
        
        // @brief クレジットパネルを表示 or 非表示にする
        public void ShowOrHideCreditPanel()
        {
            creditPanel.SetActive(!creditPanel.activeSelf);
        }

        // @brief ゲーム終了の確認画面を表示 or 非表示にする
        public void ShowOrHideQuitPanel()
        {
            if (quitPanel.activeSelf) // パネルが表示されているときは、閉じる
            {
                quitPanel.transform.DOLocalMoveY(850, 0.5f)
                    .SetEase(Ease.OutSine)
                    .OnComplete(() => quitPanel.SetActive(false));
            }
            else                      // パネルが表示されていないときは、開く
            {
                quitPanel.SetActive(true);
                quitPanel.transform.DOLocalMoveY(0, 0.5f)
                    .SetEase(Ease.OutSine);
            }
        }
    }
}