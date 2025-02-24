using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

    [SerializeField]
    private Transform resPown;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "spikes")
        {
            Debug.Log("me muero");
            //quitar vida aqui
            Debug.Log("me muero");
            collision.transform.position = resPown.position;
        }
    }
}
