using System.Collections;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private SpriteRenderer rend;
#pragma warning disable 0649
    [SerializeField]
    private Sprite[] asteroidSprites;
#pragma warning restore 0649
    private Camera cam;
    private AsteroidExplosionsController explosionsController;
    private Rigidbody2D rb;
    private Collider2D coll;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        explosionsController = GetComponentInChildren<AsteroidExplosionsController>();
        cam = FindObjectOfType<CameraShake>().GetComponent<Camera>();
        coll = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        AsteroidsManager.enabledAsteroidsCount++;
        coll.enabled = true;
        rend.sprite = asteroidSprites[0];
        DetermineInitialProperties();
        StartCoroutine(DelayDisablingAsteroid());
    }

    private void DetermineInitialProperties()
    {
        bool randX = Random.Range(0f, 1f) > 0.5f ? true : false;
        bool flipStartingSide = Random.Range(0f, 1f) > 0.5f ? true : false;
        float x = cam.orthographicSize * 2.2f;
        float y = cam.orthographicSize * cam.aspect;
        if (flipStartingSide)
        {
            if (randX)
                y = -y;
            else
                x = -x;
        }
        var startingPos = (randX == true) ? new Vector2(Random.Range(-x, x), y) : new Vector2(x, Random.Range(-y, y));
        var desiredPos = (randX == true) ? new Vector2(Random.Range(-x, x), -y) : new Vector2(-x, Random.Range(-y, y));
        transform.position = startingPos;
        rb.velocity = (desiredPos - startingPos).normalized * Random.Range(CONST_VALUES.ASTEROID_MIN_SPEED, CONST_VALUES.ASTEROID_MAX_SPEED);
    }

    private void OnDisable()
    {
        AsteroidsManager.enabledAsteroidsCount--;
    }
    private IEnumerator DelayDisablingAsteroid()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(CONST_VALUES.PLAYER_TAG))
        {
            StartCoroutine(StartChangingSprites());
        }
        if (collision.CompareTag(CONST_VALUES.BULLET_TAG))
        {
            StartCoroutine(StartChangingSprites());
            coll.enabled = false;
        }
    }
    private IEnumerator StartChangingSprites()
    {
        explosionsController.SetOffExplosions();
        for (int i = 0; i < asteroidSprites.Length; i++)
        {
            rend.sprite = asteroidSprites[i];
            yield return new WaitForSeconds(0.1f);
        }
        rend.sprite = null;
    }
}
