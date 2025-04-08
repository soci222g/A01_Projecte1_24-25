using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection_Radius_Chuck : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject dialeg;
    [SerializeField] private GameObject square;
    [SerializeField] private float detectionRadius;

    private bool startText = false;

    // Start is called before the first frame update
    void Start()
    {
        dialeg.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        //Debug.Log(distanceToPlayer);
        if (distanceToPlayer < detectionRadius && startText == false)
        {
            startText = true;
            dialeg.SetActive(true);
            square.SetActive(true);
        }
        else if(distanceToPlayer < detectionRadius)
        {
            dialeg.GetComponent<Dialogos_chuck>().ActivateText();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
