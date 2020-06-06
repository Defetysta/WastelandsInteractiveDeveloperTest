using System.Collections;
using UnityEngine;

public class ExplosionsController : MonoBehaviour
{

    [SerializeField]
    private Sprite[] explosions = null;
    private SpriteRenderer rend;
    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        rend.sprite = null;
    }
    public void SetOffExplosions()
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
