using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private AudioClip[] ballSounds;
        [SerializeField] private float randomFactor = 0.2f;
        [SerializeField] private float yPush = 15f;
        [SerializeField] private float xPush = 5f;
        private AudioSource _myAudioSource;
        private Rigidbody2D _myRigidBody2D;

        private void Start()
        {
            _myAudioSource = GetComponent<AudioSource>();
            _myRigidBody2D = GetComponent<Rigidbody2D>();
            LaunchBall();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.transform.CompareTag("Player"))
                _myRigidBody2D.velocity = new Vector2(Random.Range(-xPush, xPush), yPush);
            PlayAudio();
            ChangeDirection();
        }

        private void ChangeDirection()
        {
            Vector2 newDirection = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
            _myRigidBody2D.velocity += newDirection;
        }

        private void LaunchBall() => _myRigidBody2D.velocity = new Vector2(Random.Range(-xPush, xPush), yPush);
        private void PlayAudio()
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(clip);
        }
    }
}