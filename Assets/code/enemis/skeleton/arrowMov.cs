using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowMov : MonoBehaviour
{
    private Rigidbody2D r;
    [SerializeField]
    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector2(speed * 10000000, 0), ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out hp perderVida) && collision.gameObject.tag == "player")
        {
            //perderVida.setHP(1);
            collision.gameObject.GetComponent<hp>().setHP(1);
            Debug.Log("loose HP");
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
