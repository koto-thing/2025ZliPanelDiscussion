using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace OSCSample
{
    public class ResultPresenter : IInitializable, ITickable, IDisposable
    {
        private ResultModel model;
        private ResultView view;
        private MobileOSCModel oscModel;
        private PlayerModel playerModel;
        private OSCSampleStateModel stateModel;

        public ResultPresenter(ResultModel model, ResultView view, MobileOSCModel oscModel, PlayerModel playerModel, OSCSampleStateModel stateModel)
        {
            this.model = model;
            this.view = view;
            this.oscModel = oscModel;
            this.playerModel = playerModel;
            this.stateModel = stateModel;
        }
        
        public void Initialize()
        {
            
        }
        
        public void Tick()
        {
            if(stateModel.State == OSCSampleState.GAMEOVER)
            {
                view.SetScoreText(oscModel.MaxDB, playerModel.PlayerYPos);
                view.ShowOrHideResultPanel(true);
                
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
            }
        }
        
        public void Dispose()
        {
            
        }
    }
}