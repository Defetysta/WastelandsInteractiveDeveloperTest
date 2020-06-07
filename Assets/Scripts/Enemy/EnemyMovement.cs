using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private FloatVariable movementSpeed = null;
    private Transform targetToFollow = null;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = transform.forward * CONST_VALUES.ENEMY_SPEED_MULTIPLIER;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetToFollow.position, movementSpeed.Value * Time.deltaTime);
    }
}
