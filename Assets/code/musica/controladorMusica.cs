using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorMusica : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("soundVolume"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("soundVolume", 1);
            LoadVolume();
        }
    }

    public void SetVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("soundVolume", VolumeSlider.value);
    }

    private void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat("soundVolume");
    }
}
