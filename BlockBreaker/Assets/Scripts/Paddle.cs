using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Paddle : MonoBehaviour
    {
        [SerializeField] private  float _screenWidthInUnits = 24f;
        [SerializeField] private  float _screenWidthMax = 23.5f;
        [SerializeField] private  float _screenWidthMin = 0.5f;
        private Ball _ball;

        private GameSession _theGameSession;

        private void Start()
        {
            _theGameSession = FindObjectOfType<GameSession>();
            _ball = FindObjectOfType<Ball>();
        }

        private void Update()
        {
            if (_theGameSession.IsAutoPlay())
            {
                var paddlePos = new Vector2(transform.position.x, transform.position.y);
                paddlePos.x = Mathf.Clamp(GetXPos(), _screenWidthMin, _screenWidthMax);
                transform.position = paddlePos;
            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    var posTo = new Vector2(GetXPos(), 0);
                    transform.Translate(posTo * Time.deltaTime);
                }
            }
        }

        private float GetXPos()
        {
            var pos = transform.position.x;

            if (_theGameSession.IsAutoPlay())
            {
                pos = _ball.transform.position.x;
                return pos;
            }

            var touch = Input.mousePosition.x / Screen.width * _screenWidthInUnits;
            if (pos < touch)
                pos = _screenWidthInUnits;
            else
                pos = -_screenWidthInUnits;


            return pos;
            //return Input.mousePosition.x / Screen.width * _screenWidthInUnits;
        }
    }
}