using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource[] audioSources;
    private AudioSource MusicSource;
    private AudioSource SFXSource;

    private AudioClip hoverButtonSound;
    private AudioClip clickButtonSound;
    private AudioClip turretFireSound;
    private AudioClip SpaceShipHitSound;
    private AudioClip mainMenuMusic;

    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>(true);

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
        turretFireSound = Resources.Load($"Sounds/Gameplay/LaserTurret") as AudioClip;
        SpaceShipHitSound = Resources.Load($"Sounds/Gameplay/SpaceShipHit") as AudioClip;

        mainMenuMusic = Resources.Load($"Music/MainMenuMusic") as AudioClip;

        PlayMainMenuMusic();

    }

    public void PlayHoverSound()
    {
        SFXSource.PlayOneShot(hoverButtonSound);
    }

    public void PlayClickSound()
    {
        SFXSource.PlayOneShot(clickButtonSound);
    }

    public void PlayFireSound()
    {
        SFXSource.PlayOneShot(turretFireSound);
    }

    public void PlaySpaceShipHitSound()
    {
        SFXSource.PlayOneShot(SpaceShipHitSound);
    }

    public void PlayMainMenuMusic()
    {
        MusicSource.clip = mainMenuMusic;
        MusicSource.Play();
    }

}
