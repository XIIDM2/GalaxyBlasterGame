using UnityEngine;

public class SettingsManager : MonoBehaviour, IGameManager
{
    private int currentQualityLevelIndex;
    public int CurrentQualityLevelIndex
    {
        get 
        { 
            return currentQualityLevelIndex; 
        }
        private set 
        {
            currentQualityLevelIndex = value;
            PlayerPrefs.SetInt("QualitySettings", currentQualityLevelIndex);
            PlayerPrefs.Save();
        }
    }

    public ManagerStatus Status { get; private set; }

    private void Start()
    {
        Status = ManagerStatus.Initializing;

        CurrentQualityLevelIndex = PlayerPrefs.GetInt("QualitySettings", 0);

        Status = ManagerStatus.Started;
    }

    public  void IncreaseQualitySettings()
    {
        if (CurrentQualityLevelIndex != QualitySettings.names.Length - 1)
        {
            CurrentQualityLevelIndex++;
            SetQualitySettings();
        }
    }

    public void DecreaseQualitySettings()
    {
        if (CurrentQualityLevelIndex > 0)
        {
            CurrentQualityLevelIndex--;
            SetQualitySettings();
        }
    }

    public void SetQualitySettings()
    {
        QualitySettings.SetQualityLevel(CurrentQualityLevelIndex);
    }

    public string GetQualitySettingsName()
    {
        return QualitySettings.names[CurrentQualityLevelIndex];
    }


    public void SoundToggle()
    {
        Managers.AudioController.sfxMute = !Managers.AudioController.sfxMute;
    }

    public void SoundVolume(float value)
    {
        Managers.AudioController.sfxVolume = value;
    }

    public void MusicToggle()
    {
        Managers.AudioController.MusicMute = !Managers.AudioController.MusicMute;
    }

    public void MusicVolume(float value)
    {
        Managers.AudioController.MusicVolume = value;
    }
}
