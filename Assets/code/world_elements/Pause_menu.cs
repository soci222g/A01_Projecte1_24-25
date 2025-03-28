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
    private GameObject Options_canva;

    private bool isPaused;
    void Start()
    {
        Pause_Canva.SetActive(false);
        Options_canva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && isPaused == false)
        {
            isPaused = true;
            Time.timeScale = 0;
            Pause_Canva.SetActive(true);
            Options_canva.SetActive(true);
            HUD.SetActive(false);

        }
        else if(Input.GetKeyDown("escape") && isPaused == true)
        {
            resumePause();
        }


    }

    public void resumePause()
    {
        isPaused = false;
        Time.timeScale = 1;
        Pause_Canva.SetActive(false);
        Options_canva.SetActive(false);
        HUD.SetActive(true);
    }

    public void MainMenuScean()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
