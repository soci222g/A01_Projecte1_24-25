using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldAnims : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("sUp", false);
        animator.SetBool("sIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
 
    
    }

    public void sUp()
    {
        animator.SetBool("sUp", false);
    }

    public void sIdle()
    {
        animator.SetBool("sIdle", false);
    }

    public void sDown()
    {
        animator.SetBool("sDown", false);
    }

    public void sUp2()
    {
        animator.SetBool("sUp", true);
    }

    public void sIdle2()
    {
        animator.SetBool("sIdle", true);
    }

    public void sDown2()
    {
        animator.SetBool("sDown", true);
    }

}
