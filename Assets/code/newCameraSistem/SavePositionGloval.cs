using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositionGloval : MonoBehaviour
{

    private int current_cameraPositio;
    private Vector3 newPositionSpawn;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private camerabehavior Camera;

    // Start is called before the first frame update
    private void Awake()
    {
        current_cameraPositio = 0;
        newPositionSpawn = player.transform.position;

        if (PlayerPrefs.HasKey("X"))
        {
            newPositionSpawn.x = PlayerPrefs.GetFloat("X");
        }
        else if (PlayerPrefs.HasKey("Y"))
        {

            newPositionSpawn.y = PlayerPrefs.GetFloat("Y");
        }
        else if (PlayerPrefs.HasKey("Z")) {
            newPositionSpawn.z = PlayerPrefs.GetFloat("Z");
        }


        if (PlayerPrefs.HasKey("CameraPosition"))
        {
            current_cameraPositio = PlayerPrefs.GetInt("CameraPosition");
            Debug.Log("newCameraPosition");
        }

        player.transform.position = newPositionSpawn;

        Camera.SetRoomOrigin(current_cameraPositio);

    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SaveNewPosition(-1, player.transform.position);
        }
    }

    public int GetCameraNum()
    {
        return current_cameraPositio;
    }

    public Vector3 GetPlayerPos()
    {
        return newPositionSpawn;
    }

    public void SaveNewPosition(int NewCameraPosition, Vector3 PositionPlayer) 
    {
        PlayerPrefs.SetFloat("X", PositionPlayer.x);
        PlayerPrefs.SetFloat("Y", PositionPlayer.y);
        PlayerPrefs.SetFloat("Z", PositionPlayer.z);

        PlayerPrefs.SetInt("CameraPosition", NewCameraPosition + 1);
    }
}
