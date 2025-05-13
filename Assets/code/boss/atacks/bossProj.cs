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
            rb.AddForce(new Vector2(speedX, speedY));
        }

        

    }
}
