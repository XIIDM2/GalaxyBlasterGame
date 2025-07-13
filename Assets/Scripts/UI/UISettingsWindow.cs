using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text graphicsQualityText;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;


    private void Start()
    {
        graphicsQualityText.text = Managers.SettingsController.GetQualitySettingsName();
        sfxSlider.value = Managers.AudioController.sfxVolume;
        musicSlider.value = Managers.AudioController.MusicVolume;
    }
    public void ToggleSFX()
    {
        Managers.SettingsController.SoundToggle();
    }
    public void ChangeSFXVolume(float value)
    {
        Managers.SettingsController.SoundVolume(value);
    }
    public void ToggleMusic()
    {
        Managers.SettingsController.MusicToggle();
    }

    public void ChangeMusicVolume(float value)
    {
        Managers.SettingsController.MusicVolume(value);
    }

    public void IncreaseQualitySettings()
    {
        Managers.SettingsController.IncreaseQualitySettings();
        graphicsQualityText.text = Managers.SettingsController.GetQualitySettingsName();
    }

    public void DecreaseQualitySettings()
    {
        Managers.SettingsController.DecreaseQualitySettings();
        graphicsQualityText.text = Managers.SettingsController.GetQualitySettingsName();
    }
}
