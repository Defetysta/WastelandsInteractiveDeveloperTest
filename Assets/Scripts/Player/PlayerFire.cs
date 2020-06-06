using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject bulletPrefab;
#pragma warning restore 0649
    private Camera cam;
    //float cooldownTimer = 0f;
    private Vector2 cursorInWorldPos;
    private Vector2 direction;
    private PoolingManager poolingManager;
    private string projectilesPoolTag = "PlayerProjectile";
    private GameObject newProjectile;

    private WaitUntil awaitInput = new WaitUntil(() => Input.GetMouseButton(0));
    private WaitForSeconds awaitEndOfInterval = new WaitForSeconds(CONST_VALUES.FIRING_INTERVAL);
    private void Awake()
    {
        cam = FindObjectOfType<CameraShake>().GetComponent<Camera>();
    }
    private void OnEnable()
    {
        StartCoroutine(AwaitPlayerInput());
    }

    private void Start()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }
    private IEnumerator AwaitPlayerInput()
    {
        yield return awaitInput;
        FireProjectile();
        yield return awaitEndOfInterval;
        yield return AwaitPlayerInput();
    }
    private void FireProjectile()
    {
        cursorInWorldPos = cam.ScreenToWorldPoint((Vector2)Input.mousePosition);
        direction = cursorInWorldPos - (Vector2)transform.position;
        direction.Normalize();
        newProjectile = poolingManager.SpawnFromPool(projectilesPoolTag, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));
        newProjectile.GetComponent<Rigidbody2D>().velocity = direction * CONST_VALUES.PROJECTILE_SPEED;
    }


}
