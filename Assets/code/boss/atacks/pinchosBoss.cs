using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            this.gameObject.GetComponentInParent<hp>().setHP(1);
        }
    }
}
