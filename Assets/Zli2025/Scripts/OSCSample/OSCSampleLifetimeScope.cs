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
        [SerializeField] private ResultView resultView;
        [SerializeField] private AudioControllerModel audioControllerModel;
        
        protected override void Configure(IContainerBuilder builder)
        {
            // Model
            builder.Register<OSCSampleStateModel>(Lifetime.Singleton);
            builder.Register<PlayerModel>(Lifetime.Singleton);
            builder.Register<ResultModel>(Lifetime.Singleton);
            
            // エントリポイント
            builder.RegisterEntryPoint<MobileOSCPresenter>();
            builder.RegisterEntryPoint<PlayerPresenter>();
            builder.RegisterEntryPoint<ResultPresenter>();
            
            // MonoBehaviourを継承してるやつ
            builder.RegisterComponent(mobileOscView);
            builder.RegisterComponent(playerView);
            builder.RegisterComponent(resultView);
            builder.RegisterComponent(audioControllerModel);
            builder.RegisterComponent(mobileOscModel);
        }
    }
}