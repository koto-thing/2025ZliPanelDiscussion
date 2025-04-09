using UnityEngine;

namespace OSCSample
{
    public class EffectContView : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explodeEffect;
        
        
        public ParticleSystem ExplodeEffect => explodeEffect;
    }
}