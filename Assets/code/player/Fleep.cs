using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Fleep : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField]
    private bool fleep;
    private bool fleepControler = true;
    [SerializeField]
    private bool flying;
   
    private int fleepTime = 1;
    [SerializeField]
    private float curentfleepTime;
    // Update is called once per frame




    void Start()
    {
        flying = false;
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<GroundDetector>().GetGroundDetect() == true)
            ActivateGravity();
        
    }


    private void ActivateGravity()
    {
        if (Input.GetKeyDown("space") && GetComponent<GroundDetector>().GetGroundDetect())
        {

            fleep = true;
            fleepControler = !fleepControler;

        }
        else
        {
            fleep = false;

        }
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

    public float GetTimer()
    {
        return curentfleepTime;
    }

    public bool GetFlying()
    {
        return flying;
    }
    public void SetFleep()
    {
        fleep = true;
        fleepControler = !fleepControler;
        rb.gravityScale *= -1;
        sr.flipY = !sr.flipY;
        float newVerticalVelocity = rb.velocity.y * 0.1f;
        Debug.Log(newVerticalVelocity);
        rb.velocity = new Vector2(rb.velocity.x, newVerticalVelocity);
    }
}
