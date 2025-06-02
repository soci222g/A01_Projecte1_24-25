using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOnColide : MonoBehaviour
{
    [SerializeField]
    private float InvFrames;
    [SerializeField]
    private float currentTimeInv = 0;
    private hp HP;

    

    [SerializeField]
    private Animator animator;

    [SerializeField] private float knockbackStrength = 10f;
    [SerializeField] private float knockbackDuration = 0.2f;

    private Rigidbody2D rb;
    [SerializeField]
    private float knockbackTimer = 0f;
    private bool isKnockbacked = false;
    private Vector2 knockbackDirection;


    private actionState state;
    private void Start()
    {
        
        HP = GetComponent<hp>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<actionState>();

    }

    void Update()
    {
        invMoments();
    }

    private void FixedUpdate()
    {
        if (isKnockbacked)
        {
            knockbackTimer += Time.fixedDeltaTime;
            rb.velocity = Vector2.Lerp(knockbackDirection * knockbackStrength, Vector2.zero, knockbackTimer / knockbackDuration);

            if (knockbackTimer >= knockbackDuration)
            {
                isKnockbacked = false;
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void invMoments()
    {
        if (currentTimeInv > 0) //timer del invultenrabilitat
        {
            state.startAction();
            animator.SetBool("isDamaged", true);
            currentTimeInv -= Time.deltaTime;
            gameObject.tag = "Player";
            Physics2D.IgnoreLayerCollision(9, 10, true);
            //Debug.Log("ignaorar Colision");
        }
        else
        {
            
            gameObject.tag = "player";
            animator.SetBool("isDamaged", false);
            Physics2D.IgnoreLayerCollision(9, 10, false);
            state.endAction();
            //Debug.Log("reset Colision");

        }
    }

    //trigger ebter del enemi, tru vida i trau collisions durant un temps
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && gameObject.tag == "player")
        {
            currentTimeInv = InvFrames;
            Physics2D.IgnoreLayerCollision(9, 10);
            HP.setHP(1);
            GetComponent<CameraShake>().ShakeCamera(0.2f, 0.2f);

            isKnockbacked = true;
            knockbackTimer = 0f;

            if (transform.position.x < collision.transform.position.x)
                knockbackDirection = Vector2.left;
            else
                knockbackDirection = Vector2.right;
        }
       
    }

   
}
