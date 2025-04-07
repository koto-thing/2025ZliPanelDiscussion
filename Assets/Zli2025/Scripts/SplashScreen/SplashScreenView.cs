using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Zli2025.Scripts.SplashScreen
{
    public class SplashScreenView : MonoBehaviour
    {
        [Header("表示するスプライト")] 
        [SerializeField] private List<SpriteRenderer> splashSprites;
        
        // @brief スプライトの表示を初期化する
        public void SetSpriteAlphaZero()
        {
            foreach (var splashSprite in splashSprites)
            {
                splashSprite.color = new Color(splashSprite.color.r, splashSprite.color.g, splashSprite.color.b, 0);
            }
        }

        // @brief スプライトを連続で表示する
        // @param onComplete スプライトの表示が完了したときに呼び出されるコールバック
        public void ShowSprite(Action onComplete)
        {
            var sequence = DOTween.Sequence();
            
            foreach(var splashSprite in splashSprites)
            {
                sequence
                    .Append(splashSprite.DOFade(1, 0.5f))
                    .AppendInterval(1f)
                    .Append(splashSprite.DOFade(0, 0.5f))
                    .OnComplete(() => onComplete?.Invoke());
            }
        }
    }
}