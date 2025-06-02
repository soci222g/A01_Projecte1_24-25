using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
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
        float valiuSlide = slider.value;
        if(valiuSlide > 0.8f)
        {
            RefText.text = "Very High";
        }
        else if( valiuSlide > 0.6f && valiuSlide <= 0.8f)
        {
            RefText.text = "High";
        }
        else if (valiuSlide > 0.4 && valiuSlide <= 0.6)
        {
            RefText.text = "Normal";
        }
        else if (valiuSlide > 0.2 && valiuSlide <= 0.4)
        {
            RefText.text = "Low";
        }
        else if (valiuSlide > 0 && valiuSlide <= 0.2)
        {
            RefText.text = "Very Low";
        }
    }
    public void SetVolume()
    {       
        audioMixer.SetFloat(grup, Mathf.Log10(slider.value) * 80f);
    }
}
