using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public void OnPlayerDeath()
    {
        StartCoroutine(DelayEndGame());
    }

    private IEnumerator DelayEndGame()
    {
        foreach (var item in FindObjectsOfType<AsteroidController>())
        {
            item.explosionsController.SetOffExplosions();
        }
        yield return new WaitForSeconds(1f);
        SceneLoader.Instance.LoadGameOver();
    }
}
