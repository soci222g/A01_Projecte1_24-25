using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOnColide : MonoBehaviour
{
    [SerializeField]
    private float InvFrames;
    [SerializeField]
    private float currentTimeInv = 0;
    // Update is called once per frame
    private hp HP;

    private GameObject player;

    private void Start()
    {
        HP = GetComponent<hp>();

    }
    void Update()
    {
        invMoments();
    }

    private void invMoments()
    {
        if (currentTimeInv > 0)
        {
            currentTimeInv -= Time.deltaTime;
            gameObject.tag = "Player";
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.tag = "player";
            player.GetComponent<Collider2D>().isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" && gameObject.tag == "player")
        {
            currentTimeInv = InvFrames;
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            player = collision.gameObject;
            HP.setHP(1);
            

        }
    }
}
