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
        fleep = Input.GetButton("Jump");

        if (fleep == true)
        rb.gravityScale *= -1;
    }
}
