using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_code : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void CanviarEscena(string name)
    {
        SceneManager.LoadScene(name);

        if (PlayerPrefs.HasKey("Secan"))
        {
            SceneManager.LoadScene(PlayerPrefs.GetString("Secan"));
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

}
