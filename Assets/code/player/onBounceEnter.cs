using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onBounceEnter : MonoBehaviour
{

    private hp HP;

    // Start is called before the first frame update
    void Start()
    {
        HP = GetComponentInParent<hp>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bounce")
        {
            Debug.Log(collision.gameObject.name);
            HP.setHP(1);
            GetComponentInParent<CameraShake>().ShakeCamera(0.2f, 0.2f);

        }
    }

}
