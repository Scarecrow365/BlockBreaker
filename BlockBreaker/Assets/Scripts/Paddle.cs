using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private float _speed = 24f;
        [SerializeField] private float _offsetFromBorders = 0.8f;
        private float _border;
        private Ball _ball;
        private GameSession _gameSession;

        private void Start()
        {
            _border = 1 / (Camera.main.WorldToViewportPoint(new Vector3(1, 1, 0)).x - 0.5f);
            _gameSession = FindObjectOfType<GameSession>();
            if (_gameSession != null && _gameSession.IsAutoPlay())
                _ball = FindObjectOfType<Ball>();
        }

        private void Update()
        {
            if (_gameSession != null && _gameSession.IsAutoPlay())
                AutoChaseBall();
            else
                PlayerControl();
        }

        private void PlayerControl()
        {
            if (Input.GetMouseButton(0))
            {
                float touch = Input.mousePosition.x / Screen.width;
                if (0.5f < touch)
                {
                    if (transform.position.x >= (_border / 2 - _offsetFromBorders)) return;
                    transform.Translate(Vector2.right * _speed * Time.deltaTime);
                }
                else
                {
                    if (transform.position.x <= (-(_border / 2) + _offsetFromBorders)) return;
                    transform.Translate(Vector2.left * _speed * Time.deltaTime);
                }
            }
        }

        private void AutoChaseBall()
        {
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(GetBallPosX(), -_border, _border);
            transform.position = Vector3.MoveTowards(
                transform.position,
                paddlePos,
                _speed * Time.deltaTime);
        }

        private float GetBallPosX()
        {
            if (_gameSession != null && _gameSession.IsAutoPlay())
                return _ball.transform.position.y > 4
                    ? transform.position.x
                    : _ball.transform.position.x;

            return transform.position.x;
        }
    }
}