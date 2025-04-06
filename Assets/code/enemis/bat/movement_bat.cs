using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_bat : MonoBehaviour
{

    [SerializeField]
    private List<Transform> points = new List<Transform>();
    private int NextPont;
    [SerializeField]
    private int speed;
    [SerializeField] private bool moviendoDerecha;
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = points[NextPont].position - transform.position;
        float distence = dir.magnitude;
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        if (distence < 0.1f)
        {
            NextPont++;
            Girar();
            if (NextPont >= points.Count)
            {
                NextPont = 0;
            }
        }
    }
    private void Girar()
    {
        
        spriteRenderer.flipX = !spriteRenderer.flipX;
        
    }
}
