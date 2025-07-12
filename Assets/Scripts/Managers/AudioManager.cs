using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    public ManagerStatus Status { get; private set; }

    private AudioSource[] audioSources;
    private AudioSource MusicSource;
    private AudioSource SFXSource;

    private AudioClip hoverButtonSound;
    private AudioClip clickButtonSound;
    private AudioClip mainMenuMusic;

    public void StartUp()
    {
        Status = ManagerStatus.Initializing;

        audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.InstanceID);

        foreach (AudioSource source in audioSources)
        {
            switch (source.gameObject.name)
            {
                case "SFX":
                    SFXSource = source;
                    break;
                case "Music":
                    MusicSource = source;
                    break;
                default:
                    break;
            }
        }

        SFXSource.playOnAwake = false;

        MusicSource.playOnAwake = true;
        MusicSource.loop = true;
        MusicSource.priority = 60;


        hoverButtonSound = Resources.Load($"Sounds/UI/ButtonHover") as AudioClip;
        clickButtonSound = Resources.Load($"Sounds/UI/ButtonClick") as AudioClip;

        mainMenuMusic = Resources.Load($"Sounds/Music/MainMenuMusic") as AudioClip;

        Status = ManagerStatus.Started;

        PlayMainMenuMusic();
    }

    public void PlayClip(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayHoverSound()
    {
        SFXSource.PlayOneShot(hoverButtonSound);
    }

    public void PlayClickSound()
    {
        SFXSource.PlayOneShot(clickButtonSound);
    }

    public void PlayMainMenuMusic()
    {
        MusicSource.clip = mainMenuMusic;
        MusicSource.Play();
    }

}
