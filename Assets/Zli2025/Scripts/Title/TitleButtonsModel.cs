using UnityEngine.SceneManagement;
using UnityEngine;

namespace Title
{
    public class TitleButtonsModel
    {
        public void StartButtonFunc()
        {
            SceneManager.LoadSceneAsync("OSCSample");
        }

        public void OptionButtonFunc()
        {
            
        }

        public void CreditButtonFunc()
        {
            
        }

        public void QuitButtonFunc()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}