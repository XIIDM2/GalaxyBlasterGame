using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }
    public bool DefeatState
    {
        get
        {
            return defeatState;
        }
        private set
        {
            defeatState = value;

            if (defeatState == true)
            {
                Defeat.Invoke();
            }
        }
    }

    public UnityAction Defeat;

    private Coroutine slowTimeCoroutine;

    private bool defeatState = false;

    public void StartUp()
    {
        Status = ManagerStatus.Initializing;

        Time.timeScale = 1.0f;

        DefeatState = false;

        Status = ManagerStatus.Started;
    }


    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void SetGameToDefeatState()
    {
        DefeatState = true;
        Managers.DataController.SaveGame();
    }

    public void PauseTime()
    {
        Time.timeScale = 0.0f;
    }

    public void SlowTime()
    {
        slowTimeCoroutine = StartCoroutine(SlowTimeRoutine());
    }

    public void ResetTime()
    {
        if (slowTimeCoroutine != null)
        {
            StopCoroutine(slowTimeCoroutine);
        }

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

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator SlowTimeRoutine()
    {
        float duration = 2f;
        float elapsedTime = 0.0f;
        float startedTimeScale = Time.timeScale;

        while (elapsedTime < duration)
        {
            Time.timeScale = Mathf.Lerp(startedTimeScale, 0, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 0.0f;
    }
}
