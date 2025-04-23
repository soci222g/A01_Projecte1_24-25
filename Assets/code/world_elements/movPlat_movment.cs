using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlat_movment : MonoBehaviour
{

    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;    
    [SerializeField] float speed;
    int dir;
    Animator animator;

    void Start()
    {
        dir = 1;
        transform.position = pos1.position;
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float dist;

        if (dir == 1)
        {
            dist = Mathf.Abs(transform.position.x - pos2.position.x);
        }
        else 
        {
            dist = Mathf.Abs(transform.position.x - pos1.position.x);
        }

        transform.position += transform.right * dir * speed * Time.deltaTime;

        if (dist < 0.2f)
        {
            dir *= -1;
            animator.SetInteger("dir", dir);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
