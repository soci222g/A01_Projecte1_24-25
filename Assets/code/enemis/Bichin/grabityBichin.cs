using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabityBichin : MonoBehaviour
{
    [SerializeField] private bool isFleep;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = rb.GetComponent<SpriteRenderer>();
        if (isFleep == true)
        {
            rb.gravityScale *= -1;
            sr.flipY = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getIsFleep()
    {
        return this.isFleep;
    }
}
