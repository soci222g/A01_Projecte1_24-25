using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesJugador : MonoBehaviour
{
    private Controles controles;

    [SerializeField] Vector2 direction;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float velocidadMovimiento;

    private void Awake()
    {
        controles = new();
    }

    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDissable()
    { 
        controles.Disable();
    }

    private void Update()
    {
        direction = controles.Base.Mover.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + Time.fixedDeltaTime * velocidadMovimiento * direction);
    }
}
