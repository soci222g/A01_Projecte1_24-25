using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kogmaw_state : MonoBehaviour
{

    [SerializeField] Transform player; // Referencia al jugador
    [SerializeField] float dist;
    [SerializeField] float distanceToPlayer;

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
    }

    // Update is called once per frame
    void Update()
    {

        //calc player dist
        distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (state == kogmawState.Idle) 
        {
            Debug.Log("idle");
            if (distanceToPlayer <= 7.5f)
            {
                state = kogmawState.Hiding;
            }
        }
        else if (state == kogmawState.Hiding)
        {
            Debug.Log("hiding");
            if (distanceToPlayer >= 7.5f)
            {
                state = kogmawState.Idle;
            }else if (distanceToPlayer <= dist)
            {
                state = kogmawState.Atacking;
            }
        }
        else if (state == kogmawState.Atacking)
        {
            Debug.Log("atacking");
        }else
        {
            Debug.Log("recovering");
        }
    }
}
