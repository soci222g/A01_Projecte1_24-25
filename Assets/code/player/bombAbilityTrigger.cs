using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombAbilityTrigger : MonoBehaviour
{
    public GameObject bombExploat;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private int bombCooldown = 500;
    SpriteRenderer sr;
    private bool onCooldown;
    [SerializeField]
    private float countCooldown;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        onCooldown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("x") && !onCooldown)
        {
            if (sr.flipX)
            {
                GameObject clone = Instantiate(bombExploat, transform.position - new Vector3(1.5f, 0.28f, 0), transform.rotation);
            }
            else
            {
                GameObject clone = Instantiate(bombExploat, transform.position - new Vector3(-1.5f, 0.28f, 0), transform.rotation);
            }
            onCooldown = true;
        }
    }

    private void FixedUpdate()
    {
        if (onCooldown)
        {
            countCooldown++;
            if (countCooldown >= bombCooldown)
            {
                countCooldown = 0;
                onCooldown = false;
            }
        }
    }
}