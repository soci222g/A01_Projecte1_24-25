using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAtacks : MonoBehaviour
{

    [SerializeField] private GameObject proj1;

    [SerializeField] private GameObject spike;

    [SerializeField] GameObject rayoV;

    [SerializeField] private List<GameObject> rayosH = new List<GameObject>();

    [SerializeField] List<GameObject> pinchos = new List<GameObject>();

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

    void atack2()
    {
        for (int i = 0; i < pinchos.Count; i++)
        Instantiate(spike, pinchos[i].transform.position, Quaternion.identity);
    }

    void atack3()
    {

        float minDistToPlayer = 1000;
        int target = 0;

        for (int i = 0; i < rayosH.Count; i++)
        {
            float num = Mathf.Abs(player.transform.position.y - rayosH[i].transform.position.y);

            if (num < minDistToPlayer)
            {
                minDistToPlayer = num;
                target = i;
            }
        }

        rayosH[target].SetActive(true);

        int extra = Random.Range(1, 2);
        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            if (i != target)
            {
                count++;
                if (count == extra)
                {
                    rayosH[i].SetActive(true);
                    break;
                }
            }
        }

    }


    void phase2Atk()
    {
        rayoV.GetComponent<rayosV>().spawnOther();
    }


}
