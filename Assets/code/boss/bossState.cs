using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
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
    [SerializeField] private int phaseCounter = 0;
    private Animator animator;
    private BoxCollider2D hurtBox;
    private bossAtacks atacks;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject cinematicBoss;



    [SerializeField] private GameObject CinematicaFinal;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hurtBox = GetComponent<BoxCollider2D>();
        atacks = GetComponent<bossAtacks>();
    }

    private void Update()
    {
        if (actionTimer == actionCounter)
        {
            actionCounter = 0;
            actions--;

            switch(Random.Range(0,9))
            {
                case 0:
                case 3:
                case 6:
                    animator.SetBool("atack1", true);
                    break;
                case 1:
                case 4:
                case 7:
                    animator.SetBool("atack2", true);
                    break;

                case 2:
                case 5:
                case 8:
                    animator.SetBool("atack3", true);
                    break;
            }
            
            if(actions == 0)
            {
                animator.SetBool("isTired", true);
                actions = 5;
            }
        }


    }

    public void nextPhase()
    {
        phaseCounter++;

        if (phaseCounter == 3)
        {
            phase++;
            if (phase == 2)
            {
                state = bossStatus.second;
                animator.SetBool("1to2", true);
            }
            else
            {
                state = bossStatus.third;
                atacks.GetRayoV().SetActive(false);
                if (player.GetComponent<Fleep>().GetFleepControler() == false)
                {
                    player.GetComponent<Fleep>().SetFleep();
                }
                player.GetComponent<GroundDetector>().enabled = false;
                atacks.enabled = false;
                cinematicBoss.SetActive(true);
                CinematicaFinal.SetActive(true);
                this.gameObject.SetActive(false);
              
               
            }

            phaseCounter = 0;

        }
        
    }

    void actionSum()
    {
        actionCounter++;
    }

    void deactivateHurtBox()
    {
        hurtBox.enabled = false;
    }

    void activateHurtBox()
    {
        hurtBox.enabled = true;
    }

}
