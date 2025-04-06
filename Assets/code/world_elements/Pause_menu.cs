using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause_Canva;
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private atack atack;

    private bool isPaused;
    void Start()
    {
        
        Pause_Canva.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") )
        {
            if (isPaused == false)
            {
                Cursor.lockState = CursorLockMode.None;
                isPaused = true;
                Time.timeScale = 0f;
                Pause_Canva.SetActive(true);
                HUD.SetActive(false);
                atack.enabled = false;
            }
            else
            {
                resumePause();
            }
        }
  
    }

    public void resumePause()
    {
        isPaused = false;
        Time.timeScale = 1;
        Pause_Canva.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        HUD.SetActive(true);
        atack.enabled = true;
    }

    public void MainMenuScean()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
