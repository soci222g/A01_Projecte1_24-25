using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bossAnims : MonoBehaviour
{

    Animator animator;
    BoxCollider2D boxCollider;
    [SerializeField] private GameObject shield;

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

    void sUp()
    {
        shield.GetComponent<shieldAnims>().sUp();
    }
    void sIdle()
    {
        shield.GetComponent<shieldAnims>().sIdle();
    }
    void sDown()
    {
        shield.GetComponent<shieldAnims>().sDown();
    }

    void sUp2()
    {
        shield.GetComponent<shieldAnims>().sUp2();
    }
    void sIdle2()
    {
        shield.GetComponent<shieldAnims>().sIdle2();
    }
    void sDown2()
    {
        shield.GetComponent<shieldAnims>().sDown2();
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

    void phase1to2()
    {
        animator.SetBool("1to2", false);
    }
}
