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
           
            this.gameObject.GetComponent<hp>().setHP(1);
          

            this.transform.position = resPown.position;

            if(GetComponent<Fleep>().GetFleepControler() == false)
            {
                GetComponent<Fleep>().SetFleep();
            }
        }
    }

    public void SetSpawnPont(Transform newPoint)
    {
        resPown = newPoint;
    }
}
