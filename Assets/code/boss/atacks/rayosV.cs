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

        int x = Random.Range(52, 73);

        transform.position = new Vector3(x ,transform.position.y, transform.position.z);

        gameObject.SetActive(true);

    }

    void end()
    {
       gameObject.SetActive(false);
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
