using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Level : MonoBehaviour
    {
        private int _breakableBlocks;
        private SceneLoader _sceneLoader;
        private GameSession _session;

        private void Start()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
            _session = FindObjectOfType<GameSession>();
        }

        public void CountBlocks()
        {
            _breakableBlocks++;
        }

        public void BlockDestroy()
        {
            _breakableBlocks--;
            if (_session != null && _session.IsAutoPlay()) return;

            if (_breakableBlocks <= 0)
                _sceneLoader.LoadNextScene();
        }
    }
}