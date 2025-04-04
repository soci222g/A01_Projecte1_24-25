using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kogmaw_state : MonoBehaviour
{

    [SerializeField] Transform player; // Referencia al jugador
    [SerializeField] float dist;
    [SerializeField] float distanceToPlayer;
    [SerializeField] BoxCollider2D hurtBox;
    Animator animator;

    private enum kogmawState
    {
        Idle,
        Hiding,
        Atacking,
        Recovering
    }

    [SerializeField] private kogmawState state;

    // Start is called before the first frame update
    void Start()
    {
        state = kogmawState.Idle;
        animator = GetComponent<Animator>();
        hurtBox.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        //calc player dist
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        Debug.Log(distanceToPlayer);

        if (state == kogmawState.Idle)
        {
            animator.SetBool("hide", false);
            if (distanceToPlayer <= 7.5f)
            {
                state = kogmawState.Hiding;
                animator.SetBool("hide", true);
            }
        }
        else if (state == kogmawState.Hiding)
        {
            Debug.Log("hiding");


            if (distanceToPlayer >= 7.5f)
            {
                Debug.Log("reveal");
                state = kogmawState.Idle;
                animator.SetBool("reveal", true);
                hurtBox.enabled = true;

            }
            else if (distanceToPlayer <= 2.5f)
            {
                animator.SetBool("atack", true);
                state = kogmawState.Atacking;
            }
        }
        else if (state == kogmawState.Atacking)
        {
            Debug.Log("atacking");
        }

    }

    void kogmaw_hiding()
    {
        hurtBox.enabled = false;
        animator.SetBool("hide", false);
    }

    void kogmaw_idle()
    {
        animator.SetBool("reveal", false);
    }

    void kogmaw_atack()
    {
        animator.SetBool("atack", false);
        state = kogmawState.Hiding;
    }

    void kogmaw_damage()
    {
        animator.SetBool("damage", false);
        state = kogmawState.Idle;
    }

    void kogmaw_enable_hurtBox()
    {
        hurtBox.enabled = true;
    }

    void kogmaw_disable_hurtBox()
    {
        hurtBox.enabled = false;
    }

    void kogmaw_die()
    {
        animator.SetBool("muere", false);
    }
}

