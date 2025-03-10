using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Fleep : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField]
    private bool fleep;
    private bool fleepControler = true;

    [SerializeField]
    private int fleepTime = 1;

    private float curentfleepTime;
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
        }
    }

    public void SetCurrentFleepTimer() {

        curentfleepTime = fleepTime;


    }

    public bool GetFleepControler()
    {
        return fleepControler;
    }
}
