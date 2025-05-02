using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class dropHeal : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private hp hp;

    [SerializeField]
    private AudioSource Audio;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            Debug.Log(hp.getMaxHP());
            if (collision.gameObject.GetComponent<hp>().getHP() < hp.getMaxHP())
            {
                collision.gameObject.GetComponent<hp>().setHP(-2);
                Audio.Play();
                Debug.Log(collision.gameObject.GetComponent<hp>().getHP());
                animator.SetBool("IsGot", true);

                Destroy(this.gameObject, 0.3f);
            }

        }
    }
}
