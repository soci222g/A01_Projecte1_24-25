using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public GameObject dropHeal;

    [SerializeField]
    private int HP = 10;

    private int dropChance = 100;
    private Animator animator;

    private bool isDead = false;

    private Rigidbody2D rb;

    [SerializeField] private float deathDelay = 1.2f; // tiempo que dura la animación de muerte

    [SerializeField] private AudioSource DamageAudio;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (HP <= 0 && !isDead)
        {
            Die();
        }
    }

    void takeDamage(int dmg)
    {
        HP -= dmg;
        DamageAudio.Play();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("Enemy died, triggering death animation.");

        animator.SetBool("muere", true);

        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.simulated = false;

        if (TryGetComponent<Collider2D>(out Collider2D col))
        {
            col.enabled = false;
        }

        if (TryGetComponent<enemyControllerBichin>(out enemyControllerBichin movementScript))
        {
            movementScript.enabled = false;
        }

        Debug.Log("Animator Current State: " + animator.GetCurrentAnimatorStateInfo(0).IsName("kogmaw_die"));

        Invoke(nameof(DestroyEnemy), deathDelay);
    }


    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void DropItem()
    {
        int randNum = Random.Range(1, 100);

        if (randNum < dropChance)
        {
            Vector3 dropPos = transform.position;

            if (TryGetComponent<kogmaw_state>(out kogmaw_state state))
            {
                if (transform.rotation.z == 0)
                    dropPos += new Vector3(0, +0.5f, 0);
                else
                    dropPos += new Vector3(0, - 0.5f, 0);
            }

            Instantiate(dropHeal, dropPos, transform.rotation);
        }
    }

    public int getHP() { return HP; }
    public void setHP(int dmg)
    {
        HP -= dmg;
        DamageAudio.Play();
    }
}
