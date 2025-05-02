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
        int valiuSlide = (int)(slider.value * 100);
        RefText.text = valiuSlide.ToString();
    }
    public void SetVolume()
    {
        audioMixer.SetFloat(grup, slider.value*100 - 80);
    }
}
