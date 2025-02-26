using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombAbilityTrigger : MonoBehaviour
{
    public GameObject bombExploat;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float cooldown = 0.0f;
    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("x") /*&& cooldown < 0*/)
        {
            animator.SetTrigger("Bomb2");
            if (sr.flipX)
            {
                GameObject clone = Instantiate(bombExploat, transform.position - new Vector3(1.5f, 0.28f, 0), transform.rotation);
            }
            else
            {
                GameObject clone = Instantiate(bombExploat, transform.position - new Vector3(-1.5f, 0.28f, 0), transform.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        //cooldown
    }
}
