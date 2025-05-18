using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossAnims : MonoBehaviour
{

    Animator animator;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        
    }

    void hurtAnim()
    {
        animator.SetBool("isHurt", false);
    }

    void tiredAnim()
    {
        animator.SetBool("isTired", false);
        boxCollider.enabled = false;
    }

    void atack1End()
    {
        animator.SetBool("atack1", false);
    }
    void atack2End()
    {
        animator.SetBool("atack2", false);
    }

    void atack3End()
    {
        animator.SetBool("atack3", false);
    }
}
