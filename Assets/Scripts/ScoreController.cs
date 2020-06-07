using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private IntVariable currentPoints = null;
    [SerializeField]
    private Text scoreText = null;
    private void Start()
    {
        if (currentPoints.ResetOnStart)
            currentPoints.Value = 0;
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            UpdateHighscore();
        else
            UpdateScore();
    }

    private void UpdateHighscore()
    {
        scoreText.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    private void OnDisable()
    {
        if (PlayerPrefs.GetInt("Highscore") < currentPoints.Value)
            PlayerPrefs.SetInt("Highscore", currentPoints.Value);
    }

    public void UpdateScore()
    {
        scoreText.text = currentPoints.Value.ToString();
    }
}
