using DG.Tweening;
using UnityEngine;

namespace OSCSample
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private GameObject playerObject;
        
        public GameObject PlayerObject { get => playerObject; set => playerObject = value; }

        // @brief プレイヤーを上方向に飛ばす
        public void Jump(float playerYPos)
        {
            float moveTime = 0f;
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
                moveTime = 4.0f;

            sequence
                .Append(playerObject.transform.DOLocalMoveY(playerYPos, moveTime))
                .Append(playerObject.transform.DOLocalMoveY(0, moveTime));
        }
    }
}