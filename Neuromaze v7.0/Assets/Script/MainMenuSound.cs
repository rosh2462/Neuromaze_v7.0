using UnityEngine;
using UnityEngine.UI;

public class MainMenuSound : MonoBehaviour
{
    public AudioSource musicSource;
    public Button muteButton;
    public Sprite mutedIcon;
    public Sprite unmutedIcon;

    private bool isMuted;

    private void Start()
    {
        isMuted = false;
        muteButton.image.sprite = unmutedIcon;
        muteButton.onClick.AddListener(ToggleMute);
    }

    private void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            musicSource.volume = 0f;
            muteButton.image.sprite = mutedIcon;
        }
        else
        {
            musicSource.volume = 1f;
            muteButton.image.sprite = unmutedIcon;
        }
    }
}
