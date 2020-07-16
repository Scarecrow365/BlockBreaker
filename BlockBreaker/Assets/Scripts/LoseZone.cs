using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlockBreaker.Scripts
{
    public class LoseZone : MonoBehaviour
    {
        private GameSession _gameSession;

        private void Start()
        {
            _gameSession = FindObjectOfType<GameSession>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_gameSession == null || !_gameSession.IsAutoPlay())
                SceneManager.LoadScene("GameOver");
        }
    }
}