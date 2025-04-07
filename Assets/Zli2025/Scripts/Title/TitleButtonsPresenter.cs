using System;
using VContainer.Unity;

namespace Title
{
    public class TitleButtonsPresenter : IInitializable, ITickable, IDisposable
    {
        private TitleButtonsModel model;
        private TitleButtonsView view;
        
        public TitleButtonsPresenter(TitleButtonsModel model, TitleButtonsView view)
        {
            this.model = model;
            this.view = view;
            
            SetEvents();
        }

        public void Initialize()
        {
            
        }

        public void Tick()
        {
            
        }

        // @brief ボタンのイベントを設定する
        private void SetEvents()
        {
            view.StartButton.onClick
                .AddListener(() =>
                {
                    model.StartButtonFunc();
                });
            
            view.CreditButton.onClick
                .AddListener(() =>
                {
                    view.ShowHideCreditPanel();
                });
            
            view.QuitButton.onClick
                .AddListener(() =>
                {
                    view.ShowHideQuitPanel();
                });
            
            view.CreditCloseButton.onClick
                .AddListener(() =>
                {
                    view.ShowHideCreditPanel();
                });
            
            view.QuitAcceptButton.onClick
                .AddListener(() =>
                {
                    model.QuitButtonFunc();
                });
            
            view.QuitCloseButton.onClick
                .AddListener(() =>
                {
                    view.ShowHideQuitPanel();
                });
        }

        public void Dispose()
        {
            view.StartButton.onClick.RemoveAllListeners();
            view.CreditButton.onClick.RemoveAllListeners();
            view.QuitButton.onClick.RemoveAllListeners();
        }
    }
}