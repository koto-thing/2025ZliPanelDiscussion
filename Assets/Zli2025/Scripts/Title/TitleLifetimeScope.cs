using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Title
{
    public class TitleLifetimeScope : LifetimeScope
    {
        [Header("依存関係")] 
        [SerializeField] private TitleButtonsView titleButtonsView;
        [SerializeField] private VolumeControllView volumeControllView;
        [SerializeField] private OSCMicSendModel oscMicSendModel;
        [SerializeField] private OSCMicSendView oscMicSendView;
    
        protected override void Configure(IContainerBuilder builder)
        {
            // PureC#のクラス
            builder.Register<TitleButtonsModel>(Lifetime.Singleton);
            builder.Register<VolumeControllModel>(Lifetime.Singleton);
            
            // エントリポイント
            builder.RegisterEntryPoint<TitleButtonsPresenter>();
            builder.RegisterEntryPoint<VolumeControllPresenter>();
            builder.RegisterEntryPoint<OSCMicSendPresenter>();
            
            // MonoBehaviourを継承してるやつ
            builder.RegisterComponent(titleButtonsView);
            builder.RegisterComponent(volumeControllView);
            builder.RegisterComponent(oscMicSendModel);
            builder.RegisterComponent(oscMicSendView);
        }
    }
}