using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAtacks : MonoBehaviour
{

    [SerializeField] private GameObject proj1;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void atack1()
    {
        int offset = 10;
        int dir = Random.Range(0, 1);

        if (dir == 0)
        {
            offset *= -1;
        }

        if (player.transform.position.y > transform.position.y)
        {
            Instantiate(proj1, player.transform.position + new Vector3(offset, -1.5f, 0), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            Instantiate(proj1, player.transform.position + new Vector3(offset, 1.5f, 0), Quaternion.Euler(0, 0, 0));
        }

        
    }

}
