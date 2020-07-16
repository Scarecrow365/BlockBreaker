using TMPro;
using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class GameSession : MonoBehaviour
    {
        [Range(0.5f, 1.5f)] [SerializeField] private float gameSpeed = 1f;
        [SerializeField] private bool isAutoPlay;
        [SerializeField] private int scorePerBlockDestroy = 1;
        [SerializeField] private TextMeshProUGUI scoreText;
        private int currentScore;

        private void Awake()
        {
            int gameStatusCount = FindObjectsOfType<GameSession>().Length;

            if (gameStatusCount > 1)
            {
                Destroy(gameObject);
            }
            else
            {
                if (isAutoPlay) return;
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            scoreText.text = isAutoPlay ? "" : currentScore.ToString();
        }

        private void Update()
        {
            Time.timeScale = gameSpeed;
        }

        public void AddToScore()
        {
            if (isAutoPlay) return;
            currentScore += scorePerBlockDestroy;
            scoreText.text = currentScore.ToString();
        }

        public void ResetGame()
        {
            Destroy(gameObject);
        }

        public bool IsAutoPlay()
        {
            return isAutoPlay;
        }
    }
}