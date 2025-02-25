using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleep : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField]
    private bool fleep;
    // Update is called once per frame

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ActivateGravity();
    }

    private void ActivateGravity()
    {
        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("flipeo");
            
            fleep = true;
        }
        else
            fleep = false;

        if (fleep == true)
        {
            rb.gravityScale *= -1;
            sr.flipY = !sr.flipY;
        }
    }
}
