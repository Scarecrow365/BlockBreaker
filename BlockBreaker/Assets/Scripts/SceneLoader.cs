using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadMainScene()
        {
            SceneManager.LoadScene(0);
            var p = FindObjectOfType<GameSession>();
            if (p != null)
                p.ResetGame();
        }

        public void LoadNextScene()
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}