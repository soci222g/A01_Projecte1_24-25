using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControllerBichin : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float detectionRadius = 5.0f; // Radio de detecci�n del jugador
    [SerializeField] private float patrolSpeed = 2f; // Velocidad al patrullar
    [SerializeField] private float chaseSpeed = 5f; // Velocidad m�xima al perseguir
    [SerializeField] private float acceleration = 5f; // Velocidad de aceleraci�n
    [SerializeField] private Transform controladorSuelo; // Punto de detecci�n del suelo
    [SerializeField] private Transform controladorTecho; // Punto de detecci�n del techo
    [SerializeField] private float distanciaDeteccion = 0.5f; // Distancia de detecci�n del suelo
    [SerializeField] private LayerMask capaSuelo; // Capa para detectar el suelo
    [SerializeField] private Transform controladorPared; // Punto de detecci�n de la pared
    [SerializeField] private LayerMask capaPared; // Capa para detectar la pared
    private bool moviendoDerecha = true; // Direcci�n inicial
    private float currentSpeed; // Velocidad actual
    private bool onCooldown = false;
    [SerializeField] private float countCooldown;
    [SerializeField] private int collisionCooldown = 50;

    [SerializeField] private float countCooldown2;
    [SerializeField] private int Cooldown = 500;

    private bool puedePerseguir = true;

    private bool detected = false;


    [SerializeField] private float knock = 1000;

    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentSpeed = patrolSpeed; // Iniciar con velocidad de patrullaje
    }

    void FixedUpdate()
    {
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

        // Detectar si hay pared adelante (direcci�n seg�n el movimiento)
        Vector2 direccionPared = moviendoDerecha ? Vector2.right : Vector2.left;
        RaycastHit2D informacionPared = Physics2D.Raycast(controladorPared.position, direccionPared, distanciaDeteccion, capaPared);
        Debug.DrawRay(controladorPared.position, direccionPared * distanciaDeteccion, Color.green);

        // Detectar el suelo o el techo seg�n el estado
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
        Debug.Log(collision.gameObject.name + this.name);
        if (collision.gameObject.CompareTag("player"))
        {
            onCooldown = true;
            chaseSpeed = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "atk")
        {
            if (GetComponent<grabityBichin>().getIsFleep())
            {
                if (transform.position.x < player.position.x)
                {
                    rb.AddForce(transform.right * -knock);
                }
                else
                {
                    rb.AddForce(transform.right * knock);
                }
            }
            else
            {
                if (transform.position.x > player.position.x)
                {
                    rb.AddForce(transform.right * knock);
                }
                else
                {
                    rb.AddForce(transform.right * -knock);
                }
            }
            chaseSpeed = 0f;
            animator.SetTrigger("onColide"); // Activar animaci�n de colisi�n
            puedePerseguir = false;
        } 
    }

    void checkPersecution()
    {
        puedePerseguir = true;
    }

    void animationApagada()
    {
        animator.SetBool("onColide", false); // Volver a estado normal
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
