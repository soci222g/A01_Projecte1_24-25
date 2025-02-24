using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hp : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoints = 6;
    [SerializeField]
    private int healthPoints;

    [SerializeField]
    Sprite[] fullHP;

    [SerializeField]
    SpriteRenderer spriteHP;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealthPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            healthPoints -= Damage();
        }

        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private int Damage()
    {
        int ataque = 1;

        

        return ataque;
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int getHP()
    {
        return healthPoints;
    }

    public void setHP(int perderVida)
    {
        healthPoints -= perderVida;
    }
}
