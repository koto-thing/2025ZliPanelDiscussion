using R3;

namespace OSCSample
{
    public class EffectContModel
    {
        private ReactiveProperty<bool> isPlayExplodeEffect = new ReactiveProperty<bool>(false);
        
        public bool IsPlayExplodeEffectValue { get => isPlayExplodeEffect.Value; set => isPlayExplodeEffect.Value = value; }
        
        public Observable<bool> IsPlayExplodeEffect => isPlayExplodeEffect.AsObservable();
    }
}