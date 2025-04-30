using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderFleep : MonoBehaviour
{
    [SerializeField]
    private bool CanFleep = true;

    private float CanFleepTimer = 5;
   
    private float FleepCurrentTimer = 0;

    private void FixedUpdate()
    {
        if (!CanFleep){

            if (FleepCurrentTimer >= CanFleepTimer) { 
            
                CanFleep = true;
                FleepCurrentTimer = 0;
            }
            else
            {
                FleepCurrentTimer++;
            }
        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && CanFleep)
        {
            collision.gameObject.GetComponent<Fleep>().SetFleep();
            CanFleep = false;
        }
    }
}
