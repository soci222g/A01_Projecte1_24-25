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
            this.gameObject.GetComponent<hp>().setHP(1);
            Debug.Log("me muero");
            this.transform.position = resPown.position;
        }
    }

    public void SetSpawnPont(Transform newPoint)
    {
        resPown = newPoint;
    }
}
