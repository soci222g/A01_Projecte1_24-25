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
    void FixedUpdate()
    {
        if(curentfleepTime <= 0)
        ActivateGravity();
        else
            curentfleepTime -= Time.deltaTime;


        if(flying && GetComponent<GroundDetector>().GetGroundDetect())
        {
            curentfleepTime = fleepTime;
            flying = false;
        }
    }


    private void ActivateGravity()
    {
        if (Input.GetKeyDown("q") && GetComponent<GroundDetector>().GetGroundDetect())
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
            flying = true;
        }


    }



    public bool GetFleepControler()
    {
        return fleepControler;
    }
}
