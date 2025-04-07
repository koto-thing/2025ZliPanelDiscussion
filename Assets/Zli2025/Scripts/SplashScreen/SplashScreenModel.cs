using UnityEngine.SceneManagement;

namespace Zli2025.Scripts.SplashScreen
{
    public class SplashScreenModel
    {
        public void MoveToTitleScene()
        {
            SceneManager.LoadSceneAsync("Title");
        }
    }
}