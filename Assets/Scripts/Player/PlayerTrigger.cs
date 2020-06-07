using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField]
    private GameEventRaiser playerDestroyed = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONST_VALUES.ENEMY_BULLET_TAG))
            playerDestroyed.RaiseEvent();
    }
}
