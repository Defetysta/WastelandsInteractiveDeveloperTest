using System.Collections;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private Camera cam;
    private Vector2 cursorInWorldPos;
    private Vector2 direction;
    private PoolingManager poolingManager;
    private string projectilesPoolTag = "PlayerProjectile";
    private GameObject newProjectile;

    [SerializeField]
    private AudioSource src = null;
    [SerializeField]
    private SimpleAudioEvent shootingSound = null;

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
        shootingSound.Play(src);
    }


}
