using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameObject Music;
    [SerializeField] private GameObject pauseManager;


    public void ActivatePlayerElements()
    {
        Player.GetComponent<movement>().enabled = true;
        Player.GetComponent<Fleep>().enabled = true;
        Player.GetComponent<GroundDetector>().enabled = true;
        Player.GetComponentInChildren<atack>().enabled = true;
        HUD.SetActive(true);
        Music.SetActive(true);
        pauseManager.SetActive(true);

    }
}
