using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControllerBichin : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points = new List<Transform>();
    private int NextPont;
    public Transform player;
    public float detectionRadius = 5.0f;
    [SerializeField]
    private int speed = 5;

    private Rigidbody2D rb;
    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2 (direction.x, 0);
        }
        else
        {
            Vector3 dir = points[NextPont].position - transform.position;
            float distence = dir.magnitude;
            dir.Normalize();
            
            transform.position += dir * (speed * 0.5f) * Time.deltaTime;
            if (distence < 0.1f)
            {
                NextPont++;
                if (NextPont >= points.Count)
                {
                    NextPont = 0;
                }
            }
        }
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
