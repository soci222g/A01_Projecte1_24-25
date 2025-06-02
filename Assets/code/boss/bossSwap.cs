using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSwap : MonoBehaviour
{
    [SerializeField] private GameObject bossCinematic;
    [SerializeField] private GameObject bossFinal;

    public void activateBoss()
    {
        bossCinematic.SetActive(false);
        bossFinal.SetActive(true);
    }
}
