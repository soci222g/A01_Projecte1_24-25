using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChitCode : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("Nivell_2");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("Nivell_2");
        }
    }
}
