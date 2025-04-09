using System;
using R3;
using VContainer.Unity;

namespace OSCSample
{
    public class EffectContPresenter : IInitializable, ITickable, IDisposable
    {
        private EffectContModel model;
        private EffectContView view;

        public EffectContPresenter(EffectContModel model, EffectContView view)
        {
            this.model = model;
            this.view = view;
            
            SetEvent();
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            
        }

        public void SetEvent()
        {
            model.IsPlayExplodeEffect
                .Skip(1)
                .Subscribe(isPlay =>
                {
                    if (isPlay)
                        view.ExplodeEffect.Play();
                });
        }

        public void Dispose()
        {
            
        }
    }
}