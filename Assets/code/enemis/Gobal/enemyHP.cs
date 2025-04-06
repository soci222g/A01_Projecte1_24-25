using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public GameObject dropHeal;


    [SerializeField]
    private int HP;


    private int dropChance = 100;

    private Animator animator;

    private bool onCooldown = false;
    [SerializeField] private float countCooldown;
    [SerializeField] private int deathCooldown;

    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        Debug.Log(animator.gameObject.name);

    }

    // Update is called once per frame
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
    }

    void Die()
    {
        if (isDead) return; // Evitar m�ltiples llamadas
        isDead = true;

        Debug.Log("Enemy died, playing death animation.");

        int randNum = Random.Range(1, 100);

        // Activar la animaci�n de muerte
        animator.SetBool("muere", true);

        // Dropear �tem si aplica
        if (randNum < dropChance)
        {
            Debug.Log("Dropping heal item.");
            if (this.TryGetComponent<kogmaw_state>(out kogmaw_state state))
            {
                if (transform.rotation.z == 0)
                {
                    Instantiate(dropHeal, transform.position - new Vector3(0, -0.5f, 0), transform.rotation);
                }
                else
                {
                    Instantiate(dropHeal, transform.position - new Vector3(0, +0.5f, 0), transform.rotation);
                }
               
            }
            else
            {
                Instantiate(dropHeal, transform.position - new Vector3(0, -0.5f, 0), transform.rotation);
            }
            
        }

        // Esperar un frame para asegurar que la animaci�n est� activa antes de obtener su duraci�n
        StartCoroutine(DestroyAfterAnimation());
    }

    IEnumerator DestroyAfterAnimation()
    {
        // Esperar un frame para que el Animator procese la transici�n
        yield return null;

        // Obtener la duraci�n de la animaci�n activa
        float animDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).length);

        // Destruir el objeto despu�s de que termine la animaci�n
        Destroy(gameObject, animDuration);
    }



    public int getHP() { return HP; }
    public void setHP(int hp)
    {
        HP -= hp;
    }
}
