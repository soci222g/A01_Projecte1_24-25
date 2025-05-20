using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logicaPinchosBoss : MonoBehaviour
{
    Animator anim;
    int timerPinchos;
    [SerializeField] Collider2D boxColider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("pinchado", true);
        Destroy(gameObject, 0.5f);
        if (collision.gameObject.tag == "player")
        {
            hp hp = collision.gameObject.GetComponent<hp>();
            hp.setHP(1);
        }
    }

    void startAnimOut()
    {
        anim.SetBool("pinchado", true);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }

    void enableBoxCollider()
    {
        boxColider.enabled = true;
    }
}