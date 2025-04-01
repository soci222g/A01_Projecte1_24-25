using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class hp : MonoBehaviour
{
    [SerializeField]
    private int maxHealthPoints = 10;
    [SerializeField]
    private int healthPoints;

    [SerializeField]
    Sprite[] fullHP;

   // [SerializeField]
  //  SpriteRenderer spriteHP;
    [SerializeField]
    private hpUI hpUI;
    private void Awake()
    {
        healthPoints = maxHealthPoints;
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
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
        SceneManager.LoadScene(SceneManager.loadedSceneCount);
    }

    public int getHP()
    {
        return healthPoints;
    }

    public void setHP(int perderVida)
    {
        healthPoints -= perderVida;
        hpUI.SetHP(healthPoints);
    }
}
