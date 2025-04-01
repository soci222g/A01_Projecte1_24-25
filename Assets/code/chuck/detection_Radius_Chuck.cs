using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection_Radius_Chuck : MonoBehaviour
{
    public Transform chuck;
    public float detectionRadius = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, chuck.position);

        if (distanceToPlayer < detectionRadius)
        {
            //Activat texto
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
