using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings - 2)
            currentSceneIndex = 0;

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(CONST_VALUES.GAME_OVER_SCENE_NAME);
    }
}
