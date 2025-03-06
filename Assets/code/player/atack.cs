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

    // Start is called before the first frame update
    void Start()
    {
        gD = GetComponentInParent<GroundDetector>();
        downHitbox.enabled = false;
        latHitbox.enabled = false;
        onCooldown = false;
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
            downHitbox.offset = new Vector2(0, 1.6f);
        }
        else
        {
            downHitbox.offset = new Vector2(0, -1.6f);
        }
        
        if (onCooldown) // Cooldown del ataque
        {

            countCooldown++;
            atackDurationCounter++;
           
            if (countCooldown == atackCooldown)
            {
                countCooldown = 0;
                onCooldown = false;
            }
            if (atackDurationCounter >= atackDuration)
            {
                latHitbox.enabled = false;
                downHitbox.enabled = false;
                animator.SetBool("IsAtack", false);
            }

            

        }

    }

    private void Update()
    {
    

        if (Input.GetKeyDown("v") && !onCooldown) //check input and cooldown
        {
            //check if on ground or air
            if (gD.GetGroundDetect())
            {
                latHitbox.enabled = true;
                animator.SetBool("IsAtack", true);
            }
            else
            {
                downHitbox.enabled = true;
            }

            onCooldown = true;
            atackDurationCounter = 0;
            Debug.Log("atacked");

        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.setHP(1);
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0);

            if (!gD.GetGroundDetect())
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
    }

}
