using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;

    public static AudioManager Audio;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        Audio = GetComponentInChildren<AudioManager>();

        DontDestroyOnLoad(gameObject);
    }
}

