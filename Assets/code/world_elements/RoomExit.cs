using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField]
    private camerabehavior cam;

    private bool DirectionRoom = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(cam.gameObject.name);

        if (collision.gameObject.tag == "player")
        {
            if (DirectionRoom) {
                Debug.Log("cambiar escena: alante");
                cam.setCurrenteRoom(1);
                DirectionRoom = false;
            }
            else
            {
                Debug.Log("cambiar escena: atras");
                DirectionRoom = true;
                cam.setCurrenteRoom(-1);
            }
        }
    }

    
}
