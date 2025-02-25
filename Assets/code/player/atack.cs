using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atack : MonoBehaviour
{

    [SerializeField]
    private BoxCollider2D latHitbox; //prefab de la hitbox
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
    SpriteRenderer hitbox;
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        latHitbox.enabled = false;
        onCooldown = false;
        hitbox.enabled = false;
    }

    private void FixedUpdate() // usamos FixedUpdate para que el tiempo del ataque sea consistente
    {
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
                hitbox.enabled = false;
                animator.SetBool("IsAtack", false);
            }
            else
            {
                hitbox.enabled = true;
                atackDelayCounter++;

            }


        }

    }

    private void Update()
    {

        if (Input.GetKeyDown("v") && !onCooldown) //si input de ataque y no esta en cooldown
        {
            latHitbox.enabled = true;
            Debug.Log("atacked");
            onCooldown = true;
            atackDurationCounter = 0;
            atackDelayCounter = 0;
            animator.SetBool("IsAtack", true);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.HP -= 1;
        }
    }

}
