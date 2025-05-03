using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private string grup;
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI RefText;

    [SerializeField]
    private AudioSource Prueba;
    
    private void Awake()
    {
        slider = GetComponent<Slider>();

    }

    public void activateSound()
    {
            Prueba.Play();
    }
    private void Update()
    {
        int valiuSlide = (int)slider.value;
        if(valiuSlide > -13)
        {
            RefText.text = "Very High";
        }
        else if( valiuSlide > -26 && valiuSlide < -13)
        {
            RefText.text = "High";
        }
        else if (valiuSlide > -39 && valiuSlide < -26)
        {
            RefText.text = "Normal";
        }
        else if (valiuSlide > -52 && valiuSlide < -39)
        {
            RefText.text = "Low";
        }
        else if (valiuSlide > -65 && valiuSlide < -52)
        {
            RefText.text = "Very Low";
        }
    }
    public void SetVolume()
    {
        audioMixer.SetFloat(grup, slider.value);
    }
}
