using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHp : MonoBehaviour
{
    BoxCollider2D hurtBox;
    bossState state;
    Animator animator;

    void Start()
    {
        hurtBox = GetComponent<BoxCollider2D>();
        hurtBox.enabled = false;
        state = GetComponent<bossState>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "atk")
        {
            animator.SetBool("isHurt", true);
            animator.SetBool("isTired", false);
        }
    }

}
