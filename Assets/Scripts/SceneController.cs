using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    public void ResetTime()
    {
        Time.timeScale = 1.0f;
    }

    public void RestartScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
