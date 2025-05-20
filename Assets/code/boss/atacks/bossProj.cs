using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossProj : MonoBehaviour
{

    [SerializeField] float speedX;
    [SerializeField] float speedY;

    GameObject player;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("player");
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > player.transform.position.x)
        {
            rb.AddForce(new Vector2(-speedX, 0));
        }
        else
        {
            rb.AddForce(new Vector2(speedX, 0));
        }

        if (transform.position.y > player.transform.position.y)
        {
            rb.AddForce(new Vector2(0, -speedY));
        }
        else
        {
            rb.AddForce(new Vector2(0, speedY));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "movPlat")
        {
            return;
        }
        rb.velocity = Vector2.zero;

        if (collision.gameObject.tag == "player")
        {
            hp hp = collision.gameObject.GetComponent<hp>();
            hp.setHP(1);
        }

        Destroy(gameObject);

    }
}
