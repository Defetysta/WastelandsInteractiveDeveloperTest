using System.Collections;
using UnityEngine;

public class JetEngineController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] explosions = null;
    private SpriteRenderer rend;
    private PlayerMovemement playerMovement;
    private Vector3 baseScale;
    private void Awake()
    {
        baseScale = transform.localScale;
        playerMovement = gameObject.transform.parent.GetComponent<PlayerMovemement>();
        rend = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        StartCoroutine(SwapRenderedSprite());
    }
    private void OnEnable()
    {
        rend.sprite = null;
    }
    private void Update()
    {
        transform.localScale = baseScale * playerMovement.GetRelativeSpeed();
    }

    private IEnumerator SwapRenderedSprite()
    {
        for (int i = 0; i < explosions.Length; i++)
        {
            rend.sprite = explosions[i];
            yield return new WaitForSeconds(0.1f);
        }
        yield return StartCoroutine(SwapRenderedSprite());
    }
}
