using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPinchosBoss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0.5f);
    }
}
