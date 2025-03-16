using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flipUI : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField]
    private Fleep fleep;
    private Image Image;

    // Start is called before the first frame update
    void Start()
    {
        Image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fleep.GetFleepControler())
        {
            CambioDeSprite();
            Debug.Log("Flip");
        }
        else 
        {
            Debug.Log("No Flip");
        }
    }

    private void CambioDeSprite()
    {
        Image.sprite = Resources.Load<Sprite>("ui_2");
    }
}
