using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    [SerializeField]
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Die();
        }
    }

    void takeDamage(int dmg)
    {
        HP -= dmg;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
