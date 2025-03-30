using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControllerBichin : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float detectionRadius = 5.0f; // Radio de detección del jugador
    [SerializeField] private float patrolSpeed = 2f; // Velocidad al patrullar
    [SerializeField] private float chaseSpeed = 5f; // Velocidad máxima al perseguir
    [SerializeField] private float acceleration = 5f; // Velocidad de aceleración
    [SerializeField] private Transform controladorSuelo; // Punto de detección del suelo
    [SerializeField] private Transform controladorTecho; // Punto de detección del techo
    [SerializeField] private float distanciaDeteccion = 0.5f; // Distancia de detección del suelo
    [SerializeField] private LayerMask capaSuelo; // Capa para detectar el suelo
    [SerializeField] private Transform controladorPared; // Punto de detección de la pared
    [SerializeField] private LayerMask capaPared; // Capa para detectar la pared
    private bool moviendoDerecha = true; // Dirección inicial
    private float currentSpeed; // Velocidad actual
    private bool onCooldown = false;
    [SerializeField] private float countCooldown;
    [SerializeField] private int collisionCooldown = 50;

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
        else
        {
            if (distanceToPlayer < detectionRadius)
            {
                PerseguirJugador();
            }
            else
            {
                Patrullar();
            }
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
    }

    private void Patrullar()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, patrolSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2((moviendoDerecha ? currentSpeed : -currentSpeed), rb.velocity.y);

        // Detectar si hay pared adelante (dirección según el movimiento)
        Vector2 direccionPared = moviendoDerecha ? Vector2.right : Vector2.left;
        RaycastHit2D informacionPared = Physics2D.Raycast(controladorPared.position, direccionPared, distanciaDeteccion, capaPared);
        Debug.DrawRay(controladorPared.position, direccionPared * distanciaDeteccion, Color.green);


        if (GetComponent<grabityEnemi>().getIsFleep())
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



        // Si no hay suelo o hay una pared, girar
       
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
            animator.SetTrigger("onColide"); // Activar animación de colisión
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            animator.SetBool("onColide", false); // Volver a estado normal
        }
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
