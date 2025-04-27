using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
  
    public void SetVolume()
    {
        audioMixer.SetFloat(grup, slider.value);
    }
}
