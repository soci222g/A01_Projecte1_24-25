using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombExploat : MonoBehaviour
{
    [SerializeField]
    private float currentTimeBomb = 1f;
    private float timeAnim = 1.27f;
    [SerializeField]
    private Animator animator;

    void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void Update()
    {
        if (currentTimeBomb >= 0)
        {
            currentTimeBomb -= Time.deltaTime;
        }
        else
        {
            animator.SetBool("inAnim", true);
            if(timeAnim >= 0)
            {
                timeAnim -= Time.deltaTime;
            }
            else
            {
                animator.SetBool("exploat", true);
                GetComponent<CircleCollider2D>().enabled = true;
                Destroy(this.gameObject, 0.66f);
            }
        }


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.setHP(2);
        }
        if (collision.gameObject.TryGetComponent(out hp perderVida) && collision.gameObject.tag == "player")
        {
            perderVida.setHP(1);
        }
    }
}
