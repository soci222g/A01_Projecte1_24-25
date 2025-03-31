using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class rangedAtack : MonoBehaviour
{

    [SerializeField]
    GameObject proj;
    [SerializeField]
    SpriteRenderer sr;
    actionState state;


    // Start is called before the first frame update
    void Start()
    {
        state = GetComponent<actionState>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c") && state.getActionState()) //si input de ataque y no esta en cooldown
        {
            Debug.Log("pium");

            if (!sr.flipX)
            {
                Instantiate(proj, new Vector3(transform.position.x + 1.3f, transform.position.y, transform.position.z), transform.rotation);
            }
            else
            {
                Instantiate(proj, new Vector3(transform.position.x - 1.3f, transform.position.y, transform.position.z), transform.rotation);
            }

        }
    }
}

