using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class spikes : MonoBehaviour
{

    [SerializeField]
    private Transform resPown;

    private float CurrentTimePauseMovement;
    private int TimerMovementPause;

    private movement MoveCode;
    private Fleep FleepCode;
    private Animator Animator;

    private string spikeTag = "spikes";

    [SerializeField] private float speed;

    private bool muerto = false;

    private bool isBeingStunned = false;

    private bool spikeActivated = false;

    Rigidbody2D rb;
    SpriteRenderer sr;

    [SerializeField] CapsuleCollider2D hb1;
    [SerializeField] CapsuleCollider2D hb2;
    [SerializeField] GameObject hb3;

    private void Awake()
    {
        CurrentTimePauseMovement = 0;
        TimerMovementPause = 1;
        MoveCode = GetComponent<movement>();
        FleepCode = GetComponent<Fleep>();
        Animator = GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
/*
        if (Input.GetKeyDown(KeyCode.O))
        {
            spikeTag = "a";
        }
*/
    }

    private void FixedUpdate()
    {
        if (muerto)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, resPown.position, speed);
            if(Vector2.Distance(this.transform.position, resPown.position) <= 0.3)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                Animator.SetBool("llegando", true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spikeActivated) return;

        if (collision.gameObject.tag == spikeTag)
        {
            if (collision.gameObject.GetComponent<SpikeCheck>().GetCheckPlayer())
            {
                spikeActivated = true;

                this.gameObject.GetComponent<hp>().setHP(1);

                rb.gravityScale = 0;
                rb.velocity = Vector2.zero;

                hb1.enabled = false;
                hb2.enabled = false;
                hb3.SetActive(false);

                MoveCode.enabled = false;
                FleepCode.enabled = false;

                Animator.SetBool("bolita1", true);

                if(GetComponent<hp>().getHP() > 0)
                {
                    StartCoroutine(bolita1());
                }
                
            }
        }
    }

    public IEnumerator bolita1()
    {
        yield return new WaitForSeconds(0.5f);

        Animator.SetBool("bolita1", false);
        Animator.SetBool("llegando", false);

        muerto = true;

        Vector3 direction = this.transform.position - resPown.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0, 0, angle);

        this.sr.flipX = false;

        if (GetComponent<Fleep>().GetFleepControler() == false)
        {
            GetComponent<Fleep>().SetFleep();
        }
        CurrentTimePauseMovement = TimerMovementPause;

        spikeActivated = false;
    }

    public void setAnimIdle()
    {
        Animator.Play("idle_anim");
    }

    void devolverValores()
    {
        muerto = false;
        rb.gravityScale = 4;
        hb1.enabled = true;
        hb2.enabled = true;
        hb3.SetActive(true);
        MoveCode.enabled = true;
        FleepCode.enabled = true;
    }

    public void SetSpawnPont(Transform newPoint)
    {
        resPown = newPoint;
    }
}
