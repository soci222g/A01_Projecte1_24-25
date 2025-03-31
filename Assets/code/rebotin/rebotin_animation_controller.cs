using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebotin_animation_controller : MonoBehaviour
{
    
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void rebotin_rebot()
    {
        animator.SetBool("rebot", false);
    }

    void rebotin_big_rebot()
    {
        animator.SetBool("bigRebot", false);
    }
}
