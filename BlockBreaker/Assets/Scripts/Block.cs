using UnityEngine;

namespace BlockBreaker.Scripts
{
    public class Block : MonoBehaviour
    {
        private Level _level;
        private int _timesHit;

        [SerializeField] private AudioClip breakSound;
        [SerializeField] private Sprite[] hitSprites;
        [SerializeField] private GameObject sparkEffect;

        private void Start()
        {
            CountBreakableBlocks();
        }

        private void CountBreakableBlocks()
        {
            _level = FindObjectOfType<Level>();

            if (CompareTag("Breakable"))
                _level.CountBlocks();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (CompareTag("Breakable"))
                HandleHit();
        }

        private void HandleHit()
        {
            _timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (_timesHit >= maxHits)
                DestroyBlock();
            else
                ShowNextHitSprite();
        }

        private void ShowNextHitSprite()
        {
            int spriteIndex = _timesHit - 1;
            if (hitSprites[spriteIndex] != null)
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            else
                Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }

        private void DestroyBlock()
        {
            PlayBlockDestroySFX();
            _level.BlockDestroy();
            TriggerSparksEffect();
            Destroy(gameObject);
        }

        private void PlayBlockDestroySFX()
        {
            AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
            FindObjectOfType<GameSession>()?.AddToScore();
        }

        private void TriggerSparksEffect()
        {
            GameObject sparkles = Instantiate(sparkEffect, transform.position, transform.rotation);
            Destroy(sparkles, 1f);
        }
    }
}