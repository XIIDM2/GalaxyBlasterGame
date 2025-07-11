using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;

    public static AudioManager AudioController;
    public static ScenesManager ScenesController;
    public static CustomCursor CursorController;

    public static bool ManagersInit = false;


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

        DontDestroyOnLoad(gameObject);

        ManagersInit = true;
    }
}

