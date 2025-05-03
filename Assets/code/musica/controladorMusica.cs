using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorMusica : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;
    [SerializeField] private string GrupName;
    [SerializeField] private GameObject optionsParent;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(GrupName))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat(GrupName, 1);
            LoadVolume();
        }
        optionsParent.SetActive(false);
    }   

    public void SetVolume()
    {
        
        SaveVolume();
    }

    private void SaveVolume()
    {
        PlayerPrefs.SetFloat(GrupName, VolumeSlider.value);
    }

    private void LoadVolume()
    {
        VolumeSlider.value = PlayerPrefs.GetFloat(GrupName);
    }
}