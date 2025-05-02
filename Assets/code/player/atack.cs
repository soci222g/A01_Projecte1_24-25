using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atack : MonoBehaviour
{

    [SerializeField]
    private BoxCollider2D latHitbox;
    [SerializeField]
    private BoxCollider2D downHitbox;
    [SerializeField]
    int atackCooldown;
    int countCooldown;
    [SerializeField]
    int atackDuration;
    int atackDurationCounter;
    [SerializeField]
    bool onCooldown;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    SpriteRenderer playerSR;
    GroundDetector gD;
    [SerializeField] private float bounce;
    [SerializeField]
    Transform playerTR;
    [SerializeField]
    Rigidbody2D playerRB;
    [SerializeField] float offset;
    actionState state;

    [SerializeField] private AudioSource swingAudio;
    [SerializeField] private AudioSource HitAudio;


    freeze frez;



    void Start()
    {
        state = GetComponentInParent<actionState>();
        gD = GetComponentInParent<GroundDetector>();
        downHitbox.enabled = false;
        latHitbox.enabled = false;
        onCooldown = false;
        frez = GetComponentInParent<freeze>();
    }

    private void FixedUpdate() // usamos FixedUpdate para que el tiempo del ataque sea consistente
    {

        // make latHitbox face the same way as player
        if (playerSR.flipX == true)
        {
            latHitbox.offset = new Vector2(-1.3f, 0);
        }
        else
        {
            latHitbox.offset = new Vector2(1.3f, 0);
        }

        //make downHitbox be under player
        if (playerSR.flipY == true)
        {
            downHitbox.offset = new Vector2(0, offset);
        }
        else
        {
            downHitbox.offset = new Vector2(0, -offset);
        }

    }

    private void Update()
    {
    

        if (Input.GetMouseButtonDown(0) && !onCooldown && state.getActionState()) //check input and cooldown
        {
            swingAudio.Play();
            state.startAction();

            //check if on ground or air
            if (gD.GetGroundDetect())
            {
                latHitbox.enabled = true;
                animator.SetBool("IsAtack", true);
            }
            else
            {
                downHitbox.enabled = true;
                animator.SetBool("IsAirAtack", true);
            }

            onCooldown = true;
            atackDurationCounter = 0;
            Debug.Log("atacked");

        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "enemy")
        {
            HitAudio.Play();
            enemyHp.setHP(1);

            frez.setDurationFreeze(0.1f);

            Animator enemyAnim = collision.GetComponent<Animator>();

            enemyAnim.SetBool("damage", true);

            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);


            if (gD.GetGroundDetect() == false)
            {
                if (!playerSR.flipY)
                {
                    Debug.Log("bouncing");
                    playerRB.AddForce(transform.up * bounce);
                }
                else
                {
                    playerRB.AddForce(transform.up * -bounce);
                }

            }
        }
        else if (collision.gameObject.tag == "bounce")
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);

            if (!playerSR.flipY)
            {
                Debug.Log("bouncing");
                playerRB.AddForce(transform.up * bounce);
            }
            else
            {
                playerRB.AddForce(transform.up * -bounce);
            }
        }

        

    }

    

    public void lat_hitbox_deactivate()
    {
        latHitbox.enabled = false;
    }

    public void down_hitbox_activate()
    {
        downHitbox.enabled = true;
    }

    public void down_hitbox_deactivate()
    {
        downHitbox.enabled = false;
    }

    public void cooldown_off()
    {
        onCooldown = false;
        state.endAction();
    }

    public void atk_anim()
    {
        animator.SetBool("IsAtack", false);
    }

    public void air_atk_anim()
    {
        animator.SetBool("IsAirAtack", false);
    }
}
