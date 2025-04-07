using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Zli2025.Scripts.SplashScreen
{
    public class SplashScreenLifetimeScope : LifetimeScope
    {
        [Header("依存関係")]
        [SerializeField] private SplashScreenView view;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Model
            builder.Register<SplashScreenModel>(Lifetime.Singleton);
            
            // Presenter
            builder.RegisterEntryPoint<SplashScreenPresenter>();
            
            // View
            builder.RegisterComponent(view);
        }
    }
}