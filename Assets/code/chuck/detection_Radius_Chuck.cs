using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection_Radius_Chuck : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject dialeg;
    [SerializeField] private float detectionRadius;

    // Start is called before the first frame update
    void Start()
    {
        dialeg.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log(distanceToPlayer);
        if (distanceToPlayer < detectionRadius)
        {
            dialeg.SetActive(true);
            dialeg.GetComponent<Dialogos_chuck>().ActivateText();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
