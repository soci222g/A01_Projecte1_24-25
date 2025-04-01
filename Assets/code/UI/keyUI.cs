using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyUI : MonoBehaviour
{
    [SerializeField] private Key key;
    [SerializeField] private Image imageUI;
    [SerializeField] private Sprite spriteVacio;
    [SerializeField] private Sprite spriteLleno;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (key.GetComponent<Key>().GetKeyState() == false)
        {
            imageUI.sprite = spriteVacio;  // Muestra el sprite vacío
        }
        else
        {
            imageUI.sprite = spriteLleno;  // Muestra el sprite lleno cuando el cooldown termina
        }
    }
}
