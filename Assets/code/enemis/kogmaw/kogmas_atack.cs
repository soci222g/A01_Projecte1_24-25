using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kogmas_atack : MonoBehaviour
{

    [SerializeField] BoxCollider2D coll;
    [SerializeField] hp hp;

    // Start is called before the first frame update
    void Start()
    {
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void kogmaw_atack_hitbox_enabled()
    {
        coll.enabled = true;
    }


    void kogmaw_atack_hitbox_disable()
    {
        coll.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.tag == "player")
        {
            hp.setHP(1);
        }
    }
}
