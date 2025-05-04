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
        float angle = transform.rotation.eulerAngles.z;
        r = GetComponent<Rigidbody2D>();
        if (Mathf.Approximately(angle, 0))
        {
            r.AddForce(new Vector2(speed * 10000000, 0), ForceMode2D.Force);
        }
        else if (Mathf.Approximately(angle, 180))
        {
            r.AddForce(new Vector2(speed * -10000000, 0), ForceMode2D.Force);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out hp perderVida) && collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
