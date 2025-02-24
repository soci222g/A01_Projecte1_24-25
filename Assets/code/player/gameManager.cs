using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public Image[] playerHearts;
    public Sprite[] heartStatus;
    public int currentHearts;
    public int hp;

    static int minHearts = 0;
    static int maxHearts = 3;

    // Start is called before the first frame update
    void Start()
    {
        currentHearts = Mathf.Clamp(currentHearts, minHearts, maxHearts);
        hp = Mathf.Clamp(hp, 1, currentHearts * 2);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            if (i < currentHearts)
            {
                int heartHP = Mathf.Clamp(hp - i * 2, 0, 2);
                playerHearts[i].sprite = GetHeartStatus(heartHP);
            }
            else
            {
                playerHearts[i].enabled = false;
            }
        }
    }

    private Sprite GetHeartStatus(int x)
    {
        switch (x)
        {
            case 2: return heartStatus[0];
            case 1: return heartStatus[1];
            default: return heartStatus[2];
        }
    }
}
