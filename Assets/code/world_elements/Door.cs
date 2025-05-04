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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (collision.gameObject.GetComponent<Key>().GetKeyState())
            {
                animator.SetBool("open",true);      
            }
        }
    }

    
    void changeScene()
    {
        SceneManager.LoadScene(newRoomName);
    }

}
