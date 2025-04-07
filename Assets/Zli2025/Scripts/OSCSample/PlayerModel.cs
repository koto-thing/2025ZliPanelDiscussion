using R3;
using UnityEngine;

namespace OSCSample
{
    public class PlayerModel
    {
        private ReactiveProperty<bool> onJumpAvailable = new ReactiveProperty<bool>(false);

        private float playerYPos;

        public Observable<bool> OnJumpAvailable => onJumpAvailable.AsObservable();
        
        public float PlayerYPos { get => playerYPos; set => playerYPos = value; }
        
        
        public void ChangeJumpAvailable(bool isAvailable)
        {
            onJumpAvailable.Value = isAvailable;
        }

        public void Jump(float micVolume)
        {
            float newPlayerYPos = micVolume + 100 * Random.Range(0, 500);
            playerYPos = Mathf.Clamp(newPlayerYPos, 0, 6000);
        }
    }
}