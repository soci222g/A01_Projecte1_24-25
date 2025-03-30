using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robtin_rebot : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float bounce;
    [SerializeField] private float bigBounce;
    GroundDetector gd;
    Animator animator;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        gd = player.GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "player")
        {
            animator.SetBool("rebot", true);
            float playerV = rb.velocity.y;
            Debug.Log(rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Debug.Log(rb.velocity.y);
            rb.AddForce(transform.up * bounce );
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "atk" && !gd.GetGroundDetect())
        {
            animator.SetBool("bigRebot", true);
            Debug.Log(rb.velocity.y);
            float playerV = rb.velocity.y;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * bigBounce * -playerV);
        } 
    }

}
