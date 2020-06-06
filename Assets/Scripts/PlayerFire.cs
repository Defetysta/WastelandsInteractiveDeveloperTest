using UnityEngine;

public class PlayerFire : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject bulletPrefab;
#pragma warning restore 0649
    private Camera cam;
    public float fireDelay = 0.25f;
    //float cooldownTimer = 0f;
    private Vector2 cursorInWorldPos;
    private Vector2 direction;
    private PoolingManager poolingManager;
    private void Start()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }

    private void Awake()
    {
        cam = FindObjectOfType<CameraShake>().GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        cursorInWorldPos = cam.ScreenToWorldPoint((Vector2)Input.mousePosition);
        direction = cursorInWorldPos - (Vector2)transform.position;
        direction.Normalize();
        GameObject projectile = poolingManager.SpawnFromPool("PlayerProjectile", transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }

    public float speed;
}
