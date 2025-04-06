using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCheck : MonoBehaviour
{
    private bool IsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        IsPlayer = false;
    }

    private void Update()
    {
        IsPlayer = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player" || collision.gameObject.tag == "Player")
        {
            IsPlayer = true;
        }
        
    }
    public bool GetCheckPlayer()
    {
        return IsPlayer;
    }
}
