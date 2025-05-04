using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class hp : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoints;
    [SerializeField]
    private int healthPoints;

    [SerializeField]
    Sprite[] fullHP;
    private Animator anim;

   // [SerializeField]
  //  SpriteRenderer spriteHP;
    [SerializeField]
    private hpUI hpUI;
    [SerializeField]
    private AudioSource toddDamage;
    private void Awake()
    {
        maxHealthPoints = 10;
        healthPoints = maxHealthPoints;
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.P))
        {
            healthPoints = 1000;
            maxHealthPoints = 1000;
        }
       
        if (healthPoints <= 0)
        {
            anim.Play("death_anim");
        }
    }

    private int Damage()
    {
        int ataque = 1;

        

        return ataque;
    }

    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int getHP()
    {
        return healthPoints;
    }

    public int getMaxHP()
    {
        return maxHealthPoints;
    }

    public void setHP(int perderVida)
    {
        healthPoints -= perderVida;
        if(perderVida > 0)
        {
            toddDamage.Play();
        }

        if(healthPoints > maxHealthPoints)
        {
            healthPoints = maxHealthPoints;
        }

        hpUI.SetHP(healthPoints);
    }
}
