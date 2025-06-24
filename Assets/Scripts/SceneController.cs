using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController instance;
    public static SceneController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SceneController>();
            }
            return instance;
        }

    }

    private bool defeatState = false;

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

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
            return;
        }

        instance = this;
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        DefeatState = false;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void SetGameToDefeatState()
    {
        DefeatState = true;
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
