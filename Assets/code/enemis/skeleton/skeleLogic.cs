using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject arrow;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed;
    private SpriteRenderer sr;


    private AudioSource audio;

    [SerializeField] private int NumRoom;

    [SerializeField] private camerabehavior cameraBehavior;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>(); 
        animator.speed = speed;
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (player.position.x <= gameObject.transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }


    void spawnArrow()
    {
        if (sr.flipX)
        {
            
            Instantiate(arrow, transform.position - new Vector3(0.5f, 0.37f, 0), Quaternion.Euler(0, 0, 180));
        }
        else
        {
            Instantiate(arrow, transform.position - new Vector3(-0.5f, 0.37f, 0), transform.rotation);
        }

        if (cameraBehavior.getCurrentRoom() == NumRoom)
        {
            audio.Play();
        }
    }
}
