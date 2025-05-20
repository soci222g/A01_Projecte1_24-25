using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAtacks : MonoBehaviour
{

    [SerializeField] private GameObject proj1;

    [SerializeField] private GameObject spike;

    [SerializeField] GameObject rayoV;

    [SerializeField] private List<GameObject> rayosH = new List<GameObject>();

    [SerializeField] List<GameObject> pinchosSuelo = new List<GameObject>();

    [SerializeField] List<GameObject> pinchosTecho = new List<GameObject>();

    private GameObject player;

    int numAtack2 = 0;


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
        int x = Random.Range(49, 76);
        int y = Random.Range(-11, -21);

        Instantiate(proj1, new Vector3(x, y, -1), Quaternion.Euler(0, 0, 0));
    }

    void atack2()
    {
        int numAtack2 = Random.Range(1, 3);
        if(numAtack2 == 1)
        {
            for (int i = 0; i < pinchosSuelo.Count; i++)
            Instantiate(spike, pinchosSuelo[i].transform.position, Quaternion.identity);
        }
        else
        {
            for (int i = 0; i < pinchosTecho.Count; i++)
            Instantiate(spike, pinchosTecho[i].transform.position, Quaternion.Euler(0, 0, 180));
        }
        
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

        int extra = Random.Range(1, 3);
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
