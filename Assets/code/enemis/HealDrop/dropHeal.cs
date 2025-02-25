using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dropHeal : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (collision.gameObject.GetComponent<hp>().getHP() < 6) //canviar 6 per getmaxHP
            collision.gameObject.GetComponent<hp>().setHP(-1);
            animator.SetBool("IsGot", true);
            
            Destroy(this.gameObject,0.3f);

        }
    }
}
