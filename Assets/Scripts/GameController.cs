using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private GameObject menuCanvas = null;
    public void OnPlayerDeath()
    {
        StartCoroutine(DelayEndGame());
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    EnableMenu();
        //}
        //else if (Input.GetKeyDown(KeyCode.Space))
        //    ReturnFromMenu();
    }

    private void EnableMenu()
    {
        menuCanvas.SetActive(true);
        Time.timeScale = 0;

    }
    public void ReturnFromMenu()
    {
        menuCanvas.SetActive(false);
        Time.timeScale = 1;
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
