using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    private GameEventRaiser destroyPlayer = null;
    [SerializeField]
    private GameEventRaiser addPoints = null;
    [SerializeField]
    private SimpleAudioEvent onEnemyDestroyed = null;
    private EnemyController enemyController;
    private Collider2D coll;
    private AudioSource src;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
        src = GetComponent<AudioSource>();
        enemyController = GetComponent<EnemyController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONST_VALUES.PLAYER_TAG))
        {
            enemyController.GotHit();
            onEnemyDestroyed.Play(src);
            destroyPlayer.RaiseEvent();
        }
        else if (collision.CompareTag(CONST_VALUES.BULLET_TAG))
        {
            addPoints.RaiseEvent();
            onEnemyDestroyed.Play(src);
            enemyController.GotHit();
            coll.enabled = false;
        }
    }
}
