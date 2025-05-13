using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchosBoss : MonoBehaviour
{
    private string spikeTag = "spikesBoss";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == spikeTag)
        {
            if (collision.gameObject.GetComponent<SpikeCheck>().GetCheckPlayer())
            {
                this.gameObject.GetComponent<hp>().setHP(1);
            }
        }
    }
}
