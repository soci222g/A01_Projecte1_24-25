using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{

    public GameObject dropHeal;


    [SerializeField]
    private int HP;
    
   
    private int dropChance = 100;

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

    private void OnDestroy()
    {
        int randNum = Random.Range(1,100);
        if(randNum < dropChance)
        {
            GameObject clone = Instantiate(dropHeal,transform.position - new Vector3(0,0.5f,0),transform.rotation);
        }
    }
    public int getHP() { return HP; } 
    public void setHP(int hp)
    {
        HP -= hp;
    }
}
