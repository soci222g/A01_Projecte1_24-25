using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proj : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer playerSr;
    [SerializeField]
    SpriteRenderer sr;
    [SerializeField]
    float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("player");

        if (player.TryGetComponent(out SpriteRenderer playerSr))
        {
            if (playerSr.flipX)
            {
                speed = -speed;
                sr.flipX = false;
            }
        }


    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.setHP(3);
        }

        Destroy(gameObject);

    }
}
