using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robtin_rebot : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float bounce;
    GroundDetector gd;
    Animator animator;
    Rigidbody2D rb;
    SpriteRenderer sr;


    // Start is called before the first frame update
    void Start()
    {
        gd = player.GetComponent<GroundDetector>();
        animator = GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        sr = player.GetComponent<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "player")
        {
            animator.SetBool("rebot", true);
            float playerV = rb.velocity.y;
            rb.velocity = new Vector2(rb.velocity.x, 0);

            if (!sr.flipY)
            {
                Debug.Log("Si");
                rb.AddForce(transform.up * bounce);
            }
            else
            {
                Debug.Log("No");
                rb.AddForce(transform.up * -bounce);
            }

        }
    }

}
