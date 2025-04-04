using UnityEngine.SceneManagement;

namespace Title
{
    public class TitleButtonsModel
    {
        public void StartButtonFunc()
        {
            SceneManager.LoadSceneAsync("OSCSample");
        }

        public void CreditButtonFunc()
        {
            
        }

        public void QuitButtonFunc()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
                Application.Quit();
            #endif
        }
    }
}