using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Managers : MonoBehaviour
{
    public static AudioManager AudioController;
    public static ScenesManager ScenesController;
    public static DataManager DataController;
    public static CustomCursorManager CursorController;

    public static bool ManagersInit = false;

    public static int CountManagers => Instance.countManagers;
    public static int CountStartedManagers => Instance.countStartedManagers;

    public static UnityAction<int, int> ManagerStarted;

    private int countManagers;
    private int countStartedManagers = 0;

    private List<IGameManager> managers;

    public static Managers Instance;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        AudioController = GetComponentInChildren<AudioManager>();
        ScenesController = GetComponentInChildren<ScenesManager>();
        CursorController = GetComponentInChildren<CustomCursorManager>();
        DataController = GetComponentInChildren<DataManager>();

        managers = new List<IGameManager>();

        managers.Add(AudioController);
        managers.Add(ScenesController);
        managers.Add(CursorController);
        managers.Add(DataController);

        countManagers = managers.Count;

        StartCoroutine(StartUpManagers());

        DontDestroyOnLoad(gameObject);

    }

    private IEnumerator StartUpManagers()
    {
        foreach (IGameManager manager in managers)
        {
            manager.StartUp();
        }

        yield return null;


        while (countStartedManagers < countManagers)
        {
            int lastStartedManager = countStartedManagers;
            countStartedManagers = 0;

            foreach (IGameManager manager in managers)
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

