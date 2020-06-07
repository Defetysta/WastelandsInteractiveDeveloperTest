using System.Collections;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    private SpriteRenderer rend;
    [SerializeField]
    private Sprite[] asteroidSprites = null;
    [SerializeField]
    private IntVariable asteroidsCount = null;
    private Camera cam;
    private Rigidbody2D rb;
    internal ExplosionsController explosionsController;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        cam = FindObjectOfType<CameraShake>().GetComponent<Camera>();
        explosionsController = GetComponentInChildren<ExplosionsController>();
    }

    private void OnEnable()
    {
        asteroidsCount.ApplyChange(1);
        rend.sprite = asteroidSprites[0];
        DetermineInitialProperties();
        StartCoroutine(DelayDisablingAsteroid());
    }

    private void DetermineInitialProperties()
    {
        bool randX = Coinflip();
        bool flipStartingSide = Coinflip();
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

    private static bool Coinflip()
    {
        return Random.Range(0f, 1f) > 0.5f ? true : false;
    }

    private void OnDisable()
    {
        asteroidsCount.ApplyChange(-1);
    }
    private IEnumerator DelayDisablingAsteroid()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
    internal void GotHit()
    {
        StartCoroutine(StartChangingSprites());
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
