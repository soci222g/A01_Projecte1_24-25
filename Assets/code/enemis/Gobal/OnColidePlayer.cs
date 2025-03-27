using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnColidePlayer : MonoBehaviour
{
    private Collider2D cl;
    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.GetComponent<hp>().setHP(-1);
            collision.gameObject.GetComponent<Collider2D>().enabled = false;

           
        }
    }
}
