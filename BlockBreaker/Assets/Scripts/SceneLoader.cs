using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadMainScene()
        {
            SceneManager.LoadScene(0);
            GameSession gameSession = FindObjectOfType<GameSession>();
            if (gameSession != null)
                gameSession.ResetGame();
        }

        public void LoadNextScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene + 1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}