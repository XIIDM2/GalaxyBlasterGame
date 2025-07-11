using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Managers : MonoBehaviour
{
    public static AudioManager AudioController;
    public static ScenesManager ScenesController;
    public static CustomCursor CursorController;

    public static bool ManagersInit = false;

    public static int CountManagers => instance.countManagers;
    public static int CountStartedManagers => instance.countStartedManagers;

    public static UnityAction<int, int> ManagerStarted;

    private int countManagers;
    private int countStartedManagers = 0;

    private List<IStartUpManagers> managers;

    private static Managers instance;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        AudioController = GetComponentInChildren<AudioManager>();
        ScenesController = GetComponentInChildren<ScenesManager>();
        CursorController = GetComponentInChildren<CustomCursor>();

        managers = new List<IStartUpManagers>();

        managers.Add(AudioController);
        managers.Add(ScenesController);
        managers.Add(CursorController);

        countManagers = managers.Count;

        StartCoroutine(StartUpManagers());

        DontDestroyOnLoad(gameObject);

    }

    private IEnumerator StartUpManagers()
    {
        foreach (IStartUpManagers manager in managers)
        {
            manager.StartUp();
        }

        yield return null;


        while (countStartedManagers < countManagers)
        {
            int lastStartedManager = countStartedManagers;
            countStartedManagers = 0;

            foreach (IStartUpManagers manager in managers)
            {
                if (manager.Status == ManagerStatus.Started)
                {
                    countStartedManagers++;
                }
            }

            if (countStartedManagers > lastStartedManager)
            {
                ManagersInit = true;
                ManagerStarted.Invoke(countStartedManagers, countManagers);
            }

            yield return null;
        } 
    }
}

