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
    // Start is called before the first frame update
    void Start()
    {
        if (playerSr.flipX)
        {
            speed = -speed;
            sr.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.TryGetComponent(out EnemyHP enemyHp) && collision.gameObject.tag == "Enemy")
        {
            enemyHp.setHP(1);
        }

    }
}
