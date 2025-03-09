using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleep : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField]
    private bool fleep;
    private bool fleepControler = true;
    actionState state;
    // Update is called once per frame

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<actionState>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivateGravity();
    }

    private void ActivateGravity()
    {
        if (Input.GetKeyDown("space") && GetComponent<GroundDetector>().GetGroundDetect() && state.getActionState())
        {
            Debug.Log("flipeo");
            
            fleep = true;
            fleepControler = !fleepControler;
        }
        else
            fleep = false;

        if (fleep == true)
        {
            rb.gravityScale *= -1;
            sr.flipY = !sr.flipY;
        }
    }

    public bool GetFleepControler()
    {
        return fleepControler;
    }
}
