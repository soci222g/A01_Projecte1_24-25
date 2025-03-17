using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kogmaw_state : MonoBehaviour
{

    [SerializeField] Transform player; // Referencia al jugador
    [SerializeField] float dist;
    [SerializeField] float distanceToPlayer;
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
    }

    // Update is called once per frame
    void Update()
    {

        //calc player dist
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (state == kogmawState.Idle) 
        {
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
                state = kogmawState.Idle;
                animator.SetBool("reveal", true);

            }else if (distanceToPlayer <= 2.5f)
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
}
