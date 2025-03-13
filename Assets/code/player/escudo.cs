using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escudo : MonoBehaviour
{
    [SerializeField]
    private GameObject Shild;
    private BoxCollider2D ShildColl;
    private actionState state;
    private SpriteRenderer sr;


    [SerializeField]
    private int durationActivation;
    [SerializeField]
    private float currentDurationActivation;

    [SerializeField]
    private int durationCooldown;
    [SerializeField]
    private float currentDurationCooldown;

    [SerializeField]
    private bool OnCooldown;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ShildColl = Shild.GetComponent<BoxCollider2D>();
        state = GetComponent<actionState>();
        Shild.SetActive(false);
        currentDurationCooldown = 0;
        currentDurationActivation = 0;
        OnCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        shildLogic();
        
    }

    private void shildLogic()
    {
        if (Input.GetKeyDown("b"))
        {
            currentDurationActivation = durationActivation;
            fleepShild();
        }
        //accion  del input
        if (Input.GetKey("b") && OnCooldown == false)
        {
           
            if (currentDurationActivation > 0)
            {
                Shild.SetActive(true);
                state.startAction(); //no pot executar res mes
                currentDurationActivation -= Time.deltaTime;
                Debug.Log("activate duration");
            }
            else
            {
                state.endAction();
                OnCooldown = true;
                currentDurationCooldown = durationCooldown;
                Shild.SetActive(false);
            }


        }
        if (Input.GetKey("b") == false && currentDurationActivation > 0)
        {
            OnCooldown = true;
            state.endAction();
            currentDurationCooldown = durationCooldown;
            currentDurationActivation = 0;
            Shild.SetActive(false);
        }


        if (OnCooldown && currentDurationCooldown > 0)
        {
            currentDurationCooldown -= Time.deltaTime;
        }
        else if (currentDurationCooldown <= 0)
        {
            OnCooldown = false;
        }



    }

    private void fleepShild()
    {
        if (sr.flipX)
        {
            ShildColl.offset = new Vector2(-1.3f, 0);
        }
        else
        {
            ShildColl.offset = new Vector2(1.3f, 0);
        }
    }

}
