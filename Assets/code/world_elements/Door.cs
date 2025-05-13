using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private string newRoomName;
    [SerializeField] GameObject timeline;

    [SerializeField]private SavePositionGloval save;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        save.ResetSafe();
        if (collision.gameObject.tag == "player")
        {
            if (collision.gameObject.GetComponentInChildren<Key>().GetKeyState())
            {
                collision.GetComponent<movement>().GetAnimatorPlayer().SetFloat("Speed", 0);
                collision.GetComponent<actionState>().startAction();
                collision.GetComponent<movement>().enabled = false;
                collision.GetComponent<Fleep>().enabled = false;
                collision.GetComponentInChildren<atack>().enabled = false;
                animator.SetBool("open",true);      
            }
        }
    }

    
    void inicioTimeline()
    {
        timeline.SetActive(true);
    }

}
