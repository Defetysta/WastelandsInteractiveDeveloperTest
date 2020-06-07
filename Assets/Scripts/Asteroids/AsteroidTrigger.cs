using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    private AudioSource src;
    [SerializeField]
    private GameEventRaiser destroyPlayer = null;
    [SerializeField]
    private GameEventRaiser addPoints = null;
    [SerializeField]
    private SimpleAudioEvent onAsteroidDestroyed = null;
    private Collider2D coll;
    private AsteroidController asteroidController;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        src = GetComponent<AudioSource>();
        asteroidController = GetComponent<AsteroidController>();
    }

    private void OnEnable()
    {
        coll.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONST_VALUES.PLAYER_TAG))
        {
            asteroidController.GotHit();
            onAsteroidDestroyed.Play(src);
            destroyPlayer.RaiseEvent();
        }
        else if (collision.CompareTag(CONST_VALUES.BULLET_TAG))
        {
            addPoints.RaiseEvent();
            onAsteroidDestroyed.Play(src);
            asteroidController.GotHit();
            coll.enabled = false;
        }
    }
}
