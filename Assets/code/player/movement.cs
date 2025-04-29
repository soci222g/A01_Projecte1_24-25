using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private float speed = 5f;
    SpriteRenderer sr;
    public ParticleSystem dust;
    // Update is called once per frame
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if(horizontal < 0)
        {
            sr.flipX = true;
        }
        createDust();
    }

    void createDust()
    {
        dust.Play();
    }
}
