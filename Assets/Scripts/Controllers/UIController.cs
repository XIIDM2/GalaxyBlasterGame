using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void Pause()
    {
        Managers.ScenesController.PauseTime();
    }

    public void Continue()
    {
        Managers.ScenesController.ResetTime();
    }

    public void Restart()
    {
        Managers.ScenesController.ResetTime();
        Managers.ScenesController.RestartScene();
    }

    public void MainMenu()
    {
        Managers.ScenesController.ResetTime();
        Managers.ScenesController.MainMenu();
    }
}
