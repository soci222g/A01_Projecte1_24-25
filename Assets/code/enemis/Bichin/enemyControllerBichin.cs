using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControllerBichin : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 5.0f;
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private Transform controladorTecho;
    [SerializeField] private float distanciaDeteccion = 0.5f;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private Transform controladorPared;
    [SerializeField] private LayerMask capaPared;
    private bool moviendoDerecha = true;
    private float currentSpeed;
    private bool onCooldown = false;
    [SerializeField] private float countCooldown;
    [SerializeField] private int collisionCooldown = 50;

    [SerializeField] private float countCooldown2;
    [SerializeField] private int Cooldown = 500;

    private bool puedePerseguir = true;
    private bool detected = false;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isKnockbacked = false;
    private Vector2 knockbackDirection;
    private float knockbackTimer = 0f;
    [SerializeField] private float knockbackDuration = 0.3f; // Duración del knockback
    [SerializeField] private float knockbackStrength = 10f;  // Fuerza del knockback

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = patrolSpeed;
    }

    void FixedUpdate()
    {
        if (isKnockbacked)
        {
            knockbackTimer += Time.fixedDeltaTime;
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, knockbackTimer / knockbackDuration);
            if (knockbackTimer >= knockbackDuration)
            {
                isKnockbacked = false;
                puedePerseguir = true;
                chaseSpeed = 5f;
            }
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (onCooldown)
        {
            countCooldown++;
            if (countCooldown >= collisionCooldown)
            {
                countCooldown = 0;
                onCooldown = false;
                chaseSpeed = 5f;
                animator.SetBool("onColide", false);
            }
        }
        if (puedePerseguir == false)
        {
            countCooldown2++;
            if (countCooldown2 >= Cooldown)
            {
                countCooldown2 = 0;
                onCooldown = false;
                chaseSpeed = 5f;
            }
            else
            {
                chaseSpeed = 0f;
            }
        }
        if (distanceToPlayer < detectionRadius)
        {
            PerseguirJugador();
            detected = true;
        }
        else
        {
            Patrullar();
        }
    }

    private void PerseguirJugador()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        currentSpeed = Mathf.Lerp(currentSpeed, chaseSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(direction.x * currentSpeed, rb.velocity.y);

        if ((direction.x > 0 && !moviendoDerecha) || (direction.x < 0 && moviendoDerecha))
        {
            Girar();
        }

        Vector2 direccionPared = moviendoDerecha ? Vector2.right : Vector2.left;
        RaycastHit2D informacionPared = Physics2D.Raycast(controladorPared.position, direccionPared, distanciaDeteccion, capaPared);
        Debug.DrawRay(controladorPared.position, direccionPared * distanciaDeteccion, Color.green);

        if (GetComponent<grabityBichin>().getIsFleep())
        {
            RaycastHit2D informacionTecho = Physics2D.Raycast(controladorTecho.position, Vector2.up, distanciaDeteccion, capaSuelo);
            Debug.DrawRay(controladorTecho.position, Vector2.up * distanciaDeteccion, Color.red);
            if (informacionTecho.collider == null || informacionPared.collider != null)
            {
                Girar();
                rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distanciaDeteccion, capaSuelo);
            Debug.DrawRay(controladorSuelo.position, Vector2.down * distanciaDeteccion, Color.red);
            if (informacionSuelo.collider == null || informacionPared.collider != null)
            {
                Girar();
                rb.velocity = new Vector2(0, 0);
            }
        }
    }

    private void Patrullar()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, patrolSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2((moviendoDerecha ? currentSpeed : -currentSpeed), rb.velocity.y);

        Vector2 direccionPared = moviendoDerecha ? Vector2.right : Vector2.left;
        RaycastHit2D informacionPared = Physics2D.Raycast(controladorPared.position, direccionPared, distanciaDeteccion, capaPared);
        Debug.DrawRay(controladorPared.position, direccionPared * distanciaDeteccion, Color.green);

        if (GetComponent<grabityBichin>().getIsFleep())
        {
            RaycastHit2D informacionTecho = Physics2D.Raycast(controladorTecho.position, Vector2.up, distanciaDeteccion, capaSuelo);
            Debug.DrawRay(controladorTecho.position, Vector2.up * distanciaDeteccion, Color.red);
            if (informacionTecho.collider == null || informacionPared.collider != null)
            {
                Girar();
            }
        }
        else
        {
            RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distanciaDeteccion, capaSuelo);
            Debug.DrawRay(controladorSuelo.position, Vector2.down * distanciaDeteccion, Color.red);
            if (informacionSuelo.collider == null || informacionPared.collider != null)
            {
                Girar();
            }
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.localScale = new Vector3(moviendoDerecha ? 1 : -1, 1, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            onCooldown = true;
            chaseSpeed = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "atk")
        {
            isKnockbacked = true;
            knockbackTimer = 0f;
            puedePerseguir = false;
            animator.SetTrigger("onColide");

            if (GetComponent<grabityBichin>().getIsFleep())
            {
                knockbackDirection = (transform.position.x < player.position.x) ? Vector2.left : Vector2.right;
            }
            else
            {
                knockbackDirection = (transform.position.x > player.position.x) ? Vector2.right : Vector2.left;
            }

            rb.velocity = knockbackDirection * knockbackStrength;
        }
    }

    void checkPersecution()
    {
        puedePerseguir = true;
    }

    void animationApagada()
    {
        animator.SetBool("onColide", false);
    }

    void chaseSpeedReset()
    {
        chaseSpeed = 5f;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        if (controladorSuelo != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distanciaDeteccion);
        }

        if (controladorPared != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(controladorPared.position, controladorPared.position + (moviendoDerecha ? Vector3.right : Vector3.left) * distanciaDeteccion);
        }
    }
}
