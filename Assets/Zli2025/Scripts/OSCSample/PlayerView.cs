using System;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace OSCSample
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject playerObject;
        [SerializeField] private GameObject playerSprite;
        [SerializeField] private GameObject starSprite;
        [SerializeField] private TextMeshProUGUI jumpReadyText;
        
        public GameObject PlayerObject { get => playerObject; set => playerObject = value; }

        public void ShowOrHideJumpReadyText(bool isShow)
        {
            if (isShow)
                jumpReadyText.gameObject.SetActive(true);
            else
                jumpReadyText.gameObject.SetActive(false);
        }
        
        // @brief プレイヤーを上方向に飛ばす
        public void Jump(float playerYPos, Action onComplete, Action audioCallback)
        {
            float moveTime = 0f;
            bool isLimitAltitude = false;
            var sequence = DOTween.Sequence();
            
            if (playerYPos < 1000f && playerYPos >= 0f)
                moveTime = 1.0f;
            else if (playerYPos < 2000f && playerYPos >= 1000f)
                moveTime = 1.5f;
            else if(playerYPos < 3000f && playerYPos >= 2000f)
                moveTime = 2.0f;
            else if(playerYPos < 4000f && playerYPos >= 3000f)
                moveTime = 2.5f;
            else if(playerYPos < 5000f && playerYPos >= 4000f)
                moveTime = 2.8f;
            else if(playerYPos < 6000f && playerYPos >= 5000f)
                moveTime = 3.0f;
            else if (playerYPos >= 6000f)
            {
                moveTime = 1.0f;
                isLimitAltitude = true;
            }

            if (isLimitAltitude)
            {
                sequence
                    .Append(playerObject.transform.DOLocalMoveY(5000f, moveTime).SetEase(Ease.OutQuart))
                    .Append(playerObject.transform.DOScale(new Vector3(0, 0, 0), 3.0f))
                    .AppendCallback(() =>
                    {
                        playerSprite.SetActive(false);
                        playerObject.transform.localScale = new Vector3(1, 1, 1);
                    })
                    .AppendCallback(() => audioCallback?.Invoke())
                    .Append(starSprite.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1.0f))
                    .Append(starSprite.transform.DOScale(new Vector3(0, 0, 0), 1.0f))
                    .OnComplete(() => onComplete?.Invoke());
            }
            else
            {
                sequence
                    .Append(playerObject.transform.DOLocalMoveY(playerYPos, moveTime).SetEase(Ease.OutQuart))
                    .Append(playerObject.transform.DOLocalMoveY(0, moveTime).SetEase(Ease.InQuart))
                    .OnComplete(() => onComplete?.Invoke());
            }
        }
    }
}