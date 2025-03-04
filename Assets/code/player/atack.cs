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
    int atackCooldown = 5;
    [SerializeField]
    int countCooldown;
    [SerializeField]
    int atackDuration;
    [SerializeField]
    int atackDurationCounter;
    [SerializeField]
    int atackDelay;
    [SerializeField]
    int atackDelayCounter;
    [SerializeField]
    bool onCooldown;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    SpriteRenderer playerSR;
    GroundDetector gD;
    [SerializeField] private float bounce;
    [SerializeField]
    int bounceDuration;
    [SerializeField]
    int bounceDurationCounter;

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
            bounceDurationCounter++;
            countCooldown++;
            atackDurationCounter++;

            //check if has to bounce, makes it bounce baby
            if (bounceDurationCounter <= bounceDuration && gD.GetGroundDetect())
            {
                transform.position += new Vector3(0 , bounce * Time.deltaTime, 0);
            }

            if (countCooldown == atackCooldown)
            {
                countCooldown = 0;
                onCooldown = false;
            }
            if (atackDurationCounter >= atackDuration)
            {
                latHitbox.enabled = false;
                animator.SetBool("IsAtack", false);
            }
            else
            {
                atackDelayCounter++;

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
                bounceDurationCounter = 0;
            }

            onCooldown = true;
            atackDurationCounter = 0;
            atackDelayCounter = 0;
            Debug.Log("atacked");

        }

        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.setHP(1);

        }
    }

}
