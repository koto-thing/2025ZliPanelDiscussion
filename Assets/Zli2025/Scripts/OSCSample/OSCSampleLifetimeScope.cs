using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OSCSample
{
    public class OSCSampleLifetimeScope : LifetimeScope
    {
        [Header("依存関係")] 
        [SerializeField] private MobileOSCModel mobileOscModel;
        [SerializeField] private MobileOSCView mobileOscView;
        [SerializeField] private PlayerView playerView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Model
            builder.Register<OSCSampleStateModel>(Lifetime.Singleton);
            builder.RegisterComponent(mobileOscModel);
            builder.Register<PlayerModel>(Lifetime.Singleton);
            
            // Presenter
            builder.RegisterEntryPoint<MobileOSCPresenter>();
            builder.RegisterEntryPoint<PlayerPresenter>();
            
            // View
            builder.RegisterComponent(mobileOscView);
            builder.RegisterComponent(playerView);
        }
    }
}