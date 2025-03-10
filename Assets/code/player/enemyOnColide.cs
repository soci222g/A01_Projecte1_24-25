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

    private Collider2D coll;

    private Collider2D enemy = null;
    private void Start()
    {

        coll = GetComponent<Collider2D>();
        HP = GetComponent<hp>();

    }
    void Update()
    {
        invMoments();
    }

    private void invMoments()
    {
        if (currentTimeInv > 0) //timer del invultenrabilitat
        {
            currentTimeInv -= Time.deltaTime;
            gameObject.tag = "Player";
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.tag = "player";
            if(enemy != null)
            {
                Physics2D.IgnoreCollision(enemy, coll, false);
            }
        }
    }
    //trigger ebter del enemi, tru vida i trau collisions durant un temps
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy" && gameObject.tag == "player")
        {
            currentTimeInv = InvFrames;
            // collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            enemy = collision.gameObject.GetComponent<Collider2D>();

            Physics2D.IgnoreCollision(enemy, coll);            
            HP.setHP(1);
            

        }
    }
}
