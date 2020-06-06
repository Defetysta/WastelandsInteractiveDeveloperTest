using System.Collections;
using UnityEngine;

public class AsteroidExplosionsController : MonoBehaviour
{

#pragma warning disable 0649
    [SerializeField]
    private Sprite[] explosions;
#pragma warning restore 0649
    private SpriteRenderer rend;
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        rend.sprite = null;
    }
    internal void SetOffExplosions()
    {
        StartCoroutine(SequenceExplosions());
    }
    private IEnumerator SequenceExplosions()
    {
        for (int i = 0; i < explosions.Length; i++)
        {
            rend.sprite = explosions[i];
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
