using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const int X_OFFSET = 1;
    private const int Y_OFFSET = 4;
    [SerializeField]
    private FloatVariable movementSpeed = null;
    [SerializeField]
    private FloatVariable shootingInterval = null;
    [SerializeField]
    private IntVariable enemiesCount = null;
    [SerializeField]
    private AudioSource src = null;
    [SerializeField]
    private SimpleAudioEvent shootingSound = null;
    [SerializeField]
    private Sprite[] avaliableSprites = null;
    [SerializeField]
    private GameObject newProjectile;
    internal ExplosionsController explosionsController;

    private Camera cam;
    private PoolingManager poolingManager;
    private Transform target;
    private SpriteRenderer rend;
    private Vector2 bulletDirection;
    private Vector3 movementDirection;
    private string projectilesPoolTag = "EnemyProjectiles";
    private float timeElapsed;
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        target = FindObjectOfType<PlayerMovemement>().gameObject.transform;
        cam = FindObjectOfType<CameraShake>().GetComponent<Camera>();
        explosionsController = GetComponentInChildren<ExplosionsController>();
    }
    private void Start()
    {
        poolingManager = FindObjectOfType<PoolingManager>();
    }
    private void OnEnable()
    {
        enemiesCount.ApplyChange(1);
        DetermineStartingProperties();
        rend.sprite = avaliableSprites[Random.Range(0, avaliableSprites.Length - 1)];
    }
    private void OnDisable()
    {
        enemiesCount.ApplyChange(-1);
    }
    #region Determine starting properties
    private void DetermineStartingProperties()
    {
        float x = cam.orthographicSize * 2 - X_OFFSET;
        float y = cam.orthographicSize * cam.aspect - Y_OFFSET;
        bool randomizedHorizontalPosition = Coinflip();
        DeterminePosition(x, y, randomizedHorizontalPosition);
        DetermineDirection(randomizedHorizontalPosition);
    }

    private void DetermineDirection(bool randomizedHorizontalPosition)
    {
        if (randomizedHorizontalPosition == true)
            movementDirection = (target.position.y - transform.position.y < 0) ? Vector2.down : Vector2.up;
        else
            movementDirection = (target.position.x - transform.position.x < 0) ? Vector2.left : Vector2.right;
    }

    private void DeterminePosition(float x, float y, bool randomizedHorizontalPosition)
    {
        bool flipStartingSide = Coinflip();
        if (flipStartingSide == true)
        {
            if (randomizedHorizontalPosition)
                y = -y;
            else
                x = -x;
        }
        Vector2 startingPos;
        if (randomizedHorizontalPosition == true)
            startingPos = new Vector2((Coinflip() == true) ? -x / 2 : x / 2, y);
        else
            startingPos = new Vector2(x, (Coinflip() == true) ? -y / 2 : y / 2);
        transform.position = startingPos;
    }

    private bool Coinflip()
    {
        return Random.Range(0f, 1f) > 0.5f ? true : false;
    }
    #endregion
    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > shootingInterval.Value)
        {
            ShootAtTarget();
            timeElapsed = 0f;
        }
        transform.position += movementDirection * Time.deltaTime * movementSpeed.Value;

    }

    private void ShootAtTarget()
    {
        shootingSound.Play(src);
        bulletDirection = target.position - transform.position;
        bulletDirection.Normalize();
        newProjectile = poolingManager.SpawnFromPool(projectilesPoolTag, transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg));
        newProjectile.GetComponent<Rigidbody2D>().velocity = bulletDirection * CONST_VALUES.PROJECTILE_SPEED;
        shootingSound.Play(src);
    }
    internal void GotHit()
    {
        explosionsController.SetOffExplosions();
    }
}
