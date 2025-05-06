using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossState : MonoBehaviour
{
    private enum bossStatus
    {
        first,
        second,
        third
    }

    [SerializeField] private bossStatus state;

    private int phase = 1;
    [SerializeField] private int actions;
    [SerializeField] private int actionCounter = 0;
    [SerializeField] private int actionTimer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (actionTimer == actionCounter)
        {
            actionCounter = 0;
            actions--;
            
            if(actions == 0)
            {
                animator.SetBool("isTired", true);
                //set hurtbox true
                actions = 5;
            }
        }


    }

    public void nextPhase()
    {
        phase++;

        if (phase == 2)
        {
            state = bossStatus.second;
        }
        else
        {
            state = bossStatus.third;
        }
    }

    void actionSum()
    {
        actionCounter++;
    }

}
