using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    [SerializeField]
    private float speed = 5f;

    private float horizontal;
    SpriteRenderer sr;
    [SerializeField] private ParticleSystem dust;
    [SerializeField] private ParticleSystem dustFlip;

    actionState state;

    GroundDetector groundDetector;

    atack atk;

    // Update is called once per frame

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        groundDetector = GetComponent<GroundDetector>();
        state = GetComponent<actionState>();
        atk = GetComponentInChildren< atack>();
    }
    
    void FixedUpdate()
    {

        if (!animator.GetBool("IsAirAtack") && !animator.GetBool("IsAtack") && !state.getActionState())
        {
            atk.cooldown_off();
        }



        if (!groundDetector.GetGroundDetect())
        {
            animator.SetBool("isGrounded", false);
            speed = 8f;
        }
        else 
        {
            animator.SetBool("isGrounded", true);
            atk.down_hitbox_deactivate();
            if (animator.GetBool("IsAirAtack"))
            {
                atk.cooldown_off();
                animator.SetBool("IsAirAtack", false);
            }
        }

        horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        if (horizontal > 0)
        {
            sr.flipX = false;
        }
        else if(horizontal < 0)
        {
            sr.flipX = true;
        }
        if (GetComponent<GroundDetector>().GetGroundDetect() == true && horizontal != 0 && !Input.GetKeyDown("space"))
            createDust();
    }

    void createDust()
    {
        if (GetComponent<Fleep>().GetFleepControler() == false)
        {
            dustFlip.Play();
        }
        else
        {
            dust.Play();
        } 
    }

    public void setSpeed(float newSpeed) 
    {
        speed = newSpeed; 
    }
    public Animator GetAnimatorPlayer()
    {
        return animator;
    }
}
