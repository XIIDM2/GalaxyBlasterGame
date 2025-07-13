using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void PauseGame()
    {
        Managers.ScenesController.PauseTime();
    }

    public void UnPauseGame()
    {
        Managers.ScenesController.ResetTime();
    }

    public void Continue()
    {
        Managers.ScenesController.ResetTime();
        Managers.DataController.LoadGame();
        SceneManager.LoadScene(1);
    }

    public void NewGame()
    {
        Managers.ScenesController.ResetTime();
        Managers.DataController.ResetData();
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        Managers.ScenesController.ResetTime();
        Managers.ScenesController.RestartScene();
        Managers.DataController.LoadGame();
    }

    public void MainMenu()
    {
        Managers.ScenesController.ResetTime();
        Managers.DataController.SaveGame();
        Managers.ScenesController.MainMenu();
    }

    public void Exit()
    {
        Managers.ScenesController.ExitGame();
    }
}
