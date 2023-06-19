using UnityEngine;
using UnityEngine.UI;

public class MusicManagerSlider : MonoBehaviour
{
    public Slider soundSlider;

    public AudioSource[] audioSources;

    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();

        
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SoundVolume");
            soundSlider.value = savedVolume;
            UpdateSoundVolume(savedVolume);
        }
        else
        {
            soundSlider.value = 1f;
            UpdateSoundVolume(1f);
        }

        
        soundSlider.onValueChanged.AddListener(UpdateSoundVolume);
    }

    private void UpdateSoundVolume(float volume)
    {
        
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
        }

        
        PlayerPrefs.SetFloat("SoundVolume", volume);
    }
}
