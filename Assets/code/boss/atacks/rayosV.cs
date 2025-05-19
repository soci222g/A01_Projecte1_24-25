using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class rayosV : MonoBehaviour
{

    GameObject boss;
    BoxCollider2D hbox;

    // Start is called before the first frame update
    void Start()
    {
        hbox = GetComponent<BoxCollider2D>();
        hbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnOther()
    {
        boss = GameObject.FindGameObjectWithTag("bounce");

        float offset = Random.Range(3f, 10f);
        int dir = Random.Range(0, 2);

        if (dir == 0)
        {
            Instantiate(gameObject, boss.transform.position + new Vector3(offset, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(gameObject, boss.transform.position + new Vector3(-offset, 0, 0), Quaternion.Euler(0, 0, 0));
        }
        

    }

    void end()
    {
        Destroy( gameObject );
    }

    void hitboxDeactivete()
    {
        hbox.enabled = false;
    }

    void hitboxActivete()
    {
        hbox.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "player")
        {
            hp hp = collision.gameObject.GetComponent<hp>();
            hp.setHP(1);
        }

    }
}
