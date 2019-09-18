using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Ball : MonoBehaviour
    {
        private bool _hasStarted;

        private AudioSource _myAudioSource;
        private Rigidbody2D _myRigidbody2D;
        private GameSession _mySession;

        [SerializeField] private Paddle _paddle1;

        private Vector2 _paddleToBallVector;
        [SerializeField] private AudioClip[] ballSounds;
        [SerializeField] private float randomFactor = 0.2f;
        [SerializeField] private float yPush = 15f;
        [SerializeField] private float xPush = 5f;

        private void Start()
        {
            _hasStarted = false;
            _paddleToBallVector = transform.position - _paddle1.transform.position;
            _myAudioSource = GetComponent<AudioSource>();
            _myRigidbody2D = GetComponent<Rigidbody2D>();
            _mySession = FindObjectOfType<GameSession>();
        }

        private void Update()
        {
            if (_hasStarted) return;
            LaunchBall();
            
            if(_mySession.IsAutoPlay())
                LockBallToPaddle();
            //LaunchOnMouseClick();
        }

        private void LaunchBall()
        {
            _myRigidbody2D.velocity = new Vector2(Random.Range(-xPush, xPush), yPush);
            _hasStarted = true;
        }

//        private void LaunchOnMouseClick()
//        {
//            if (_mySession.IsAutoPlay())
//            {
//                _myRigidbody2D.velocity = new Vector2(Random.Range(-5,5), yPush);
//                _hasStarted = true;
//            }
//            else
//            {
//                if (Input.GetMouseButtonDown(0))
//                {
//                    _myRigidbody2D.velocity = new Vector2(Random.Range(-5,5), yPush);
//                    _hasStarted = true;
//                }
//            }
//        }

        private void LockBallToPaddle()
        {
            var paddlePos = new Vector2(_paddle1.transform.position.x, _paddle1.transform.position.y);
            transform.position = paddlePos + _paddleToBallVector;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

            var clip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
            _myRigidbody2D.velocity += velocityTweak;
        }
    }
}