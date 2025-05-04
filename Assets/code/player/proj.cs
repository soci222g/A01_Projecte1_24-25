using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proj : MonoBehaviour
{

    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {

        float angle = transform.rotation.eulerAngles.z;
        
        if (angle > 180) angle -= 360;
        
        if (Mathf.Approximately(angle, 0))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Mathf.Approximately(angle, 90) || Mathf.Approximately(angle, -270))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else if (Mathf.Approximately(angle, 180) || Mathf.Approximately(angle, -180))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        else if (Mathf.Approximately(angle, 270) || Mathf.Approximately(angle, -90))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "player")
        {
            Destroy(gameObject);
        }

    }

}
