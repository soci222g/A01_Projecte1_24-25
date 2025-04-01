using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{

    [SerializeField]
    private Transform resPown;

    private float CurrentTimePauseMovement;
    private int TimerMovementPause;

    private movement MoveCode;
    private Fleep FleepCode;

    private void Awake()
    {
        CurrentTimePauseMovement = 0;
        TimerMovementPause = 1;
        MoveCode = GetComponent<movement>();
        FleepCode = GetComponent<Fleep>();
    }


    private void FixedUpdate()
    {
        if (CurrentTimePauseMovement >= 0)
        {
            MoveCode.enabled = false;
            FleepCode.enabled = false;
            CurrentTimePauseMovement -= Time.deltaTime;
        }
        else {
            MoveCode.enabled = true;
            FleepCode.enabled = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "spikes")
        {
           
            this.gameObject.GetComponent<hp>().setHP(1);
          

            this.transform.position = resPown.position;

            if(GetComponent<Fleep>().GetFleepControler() == false)
            {
                GetComponent<Fleep>().SetFleep();
            }
            CurrentTimePauseMovement = TimerMovementPause;


        }
    }

    public void SetSpawnPont(Transform newPoint)
    {
        resPown = newPoint;
    }
}
