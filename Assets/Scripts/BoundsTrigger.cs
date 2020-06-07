using UnityEngine;

public class BoundsTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform respectiveBoundary = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONST_VALUES.BULLET_TAG))
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.CompareTag(CONST_VALUES.PLAYER_TAG))
        {
            TeleportPlayer(collision.gameObject);
        }
    }

    private void TeleportPlayer(GameObject target)
    {
        target.transform.position += transform.up * (Vector3.Distance(transform.position, respectiveBoundary.position) - 1);
    }
}
