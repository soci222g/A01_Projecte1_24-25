using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
