using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class musicLvL1 : MonoBehaviour
{
    [SerializeField] private AudioSource Musica1;
    [SerializeField] private AudioSource Musica2;

    // Start is called before the first frame update
    void Start()
    {
        Musica1.Play();
        Musica2.PlayDelayed(48);
    }
}
