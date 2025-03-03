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
    [SerializeField] private float distanciaDeteccion = 0.5f; // Distancia de detección del suelo
    [SerializeField] private LayerMask capaSuelo; // Capa para detectar el suelo
    private bool moviendoDerecha = true; // Dirección inicial
    private float currentSpeed; // Velocidad actual

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = patrolSpeed; // Iniciar con velocidad de patrullaje
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Si el jugador está dentro del radio de detección, acelerar hacia él
        if (distanceToPlayer < detectionRadius)
        {
            PerseguirJugador();
        }
        else
        {
            Patrullar();
        }
    }

    private void PerseguirJugador()
    {
        Vector2 direction = (player.position - transform.position).normalized;

        // Acelerar gradualmente hacia chaseSpeed
        currentSpeed = Mathf.Lerp(currentSpeed, chaseSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2(direction.x * currentSpeed, rb.velocity.y);

        // Voltear solo si cambia de dirección
        if ((direction.x > 0 && !moviendoDerecha) || (direction.x < 0 && moviendoDerecha))
        {
            Girar();
        }
    }

    private void Patrullar()
    {
        // Reducir gradualmente la velocidad al volver a patrullar
        currentSpeed = Mathf.Lerp(currentSpeed, patrolSpeed, acceleration * Time.fixedDeltaTime);
        rb.velocity = new Vector2((moviendoDerecha ? currentSpeed : -currentSpeed), rb.velocity.y);

        // Detectar si hay suelo adelante
        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distanciaDeteccion, capaSuelo);
        Debug.DrawRay(controladorSuelo.position, Vector2.down * distanciaDeteccion, Color.red);

        // Si no hay suelo adelante, girar
        if (informacionSuelo.collider == null)
        {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.localScale = new Vector3(moviendoDerecha ? 1 : -1, 1, 1);
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
    }
}
