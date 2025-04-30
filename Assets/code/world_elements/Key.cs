using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool HaveKey = false;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No se encontr� un Animator en " + gameObject.name);
        }
        else
        {
            Debug.Log("Animator encontrado en: " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger con: " + collision.gameObject.name);

        if (collision.gameObject.tag == "key")
        {
            Debug.Log("Llave detectada, activando animaci�n.");
            HaveKey = true;
            animator.SetBool("HaveKey", true);
            animator.SetTrigger("PickUp");

            collision.gameObject.SetActive(false);
        }
    }



    public bool GetKeyState() {
        return HaveKey;
    }
}
