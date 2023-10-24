using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    public void RestartLevel()
    {
        // Get the name of the current scene.
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Load the current scene to restart it.
        SceneManager.LoadScene(currentSceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}