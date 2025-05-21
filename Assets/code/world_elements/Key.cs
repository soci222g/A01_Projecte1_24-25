using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool HaveKey = false;
    private Animator animator;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private GameObject KeyScene;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        if (animator == null)
        {
            Debug.LogError("No se encontró un Animator en " + gameObject.name);
        }
        else
        {
            //Debug.Log("Animator encontrado en: " + gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger con: " + collision.gameObject.name);

        if (collision.gameObject.tag == "key")
        {
            Debug.Log("Llave detectada, activando animación.");
            HaveKey = true;
            Audio.Play();
            animator.SetBool("HaveKey", true);
            animator.SetTrigger("PickUp");

            collision.gameObject.SetActive(false);
        }
    }


    public void SetKeyState(bool key)
    {
        HaveKey = key;
        if(KeyScene != null)
        {
            KeyScene.SetActive(false);
        }
    }
    public bool GetKeyState() {
        return HaveKey;
    }
}
