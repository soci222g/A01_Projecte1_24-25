using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class rayosH : MonoBehaviour
{
    
    Animator animator;
    BoxCollider2D hbox;

    void Start()
    {
        animator = GetComponent<Animator>();
        hbox = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void deactivate()
    {
        gameObject.SetActive(false);
    }

    void hitboxActivete()
    {
        hbox.enabled = true;
    }

    void hitboxDeactivete()
    {
        hbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "player")
        {
            hp hp = collision.gameObject.GetComponent<hp>();
            hp.setHP(1);
        }

    }
}
