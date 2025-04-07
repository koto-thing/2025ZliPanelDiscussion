using System;
using VContainer.Unity;

namespace Zli2025.Scripts.SplashScreen
{
    public class SplashScreenPresenter : IInitializable, ITickable, IDisposable
    {
        private SplashScreenModel model;
        private SplashScreenView view;
        
        public SplashScreenPresenter(SplashScreenModel model, SplashScreenView view)
        {
            this.model = model;
            this.view = view;
        }
        
        public void Initialize()
        {
            view.SetSpriteAlphaZero();
            view.ShowSprite(() => model.MoveToTitleScene());
        }

        public void Tick()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}