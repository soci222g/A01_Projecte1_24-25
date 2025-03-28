using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool HaveKey = false;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "key") {
            HaveKey = true;
            collision.gameObject.SetActive(false);
        }
    }


    public bool GetKeyState() {
        return HaveKey;
    }

   

}
