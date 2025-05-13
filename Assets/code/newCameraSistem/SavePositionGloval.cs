using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePositionGloval : MonoBehaviour
{

    private int current_cameraPositio = 0;
    [SerializeField]
    private Vector3 newPositionSpawn;

    [SerializeField]
    private Vector3 StartPosition;
    


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
        if (PlayerPrefs.HasKey("Y"))
        {
            newPositionSpawn.y = PlayerPrefs.GetFloat("Y");
        }
        if (PlayerPrefs.HasKey("Z")) {
            newPositionSpawn.z = PlayerPrefs.GetFloat("Z");
        }


        if (PlayerPrefs.HasKey("CameraPosition"))
        {
            current_cameraPositio = PlayerPrefs.GetInt("CameraPosition");
            //Debug.Log("newCameraPosition");
        }

        player.transform.position = newPositionSpawn;
        //Debug.Log(newPositionSpawn);

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

    public Vector3 GetStartPosition()
    {
        return StartPosition;
    }

    public void ResetSafe()
    {
        PlayerPrefs.SetFloat("X", StartPosition.x);
        PlayerPrefs.SetFloat("Y", StartPosition.y);
        PlayerPrefs.SetFloat("Z", StartPosition.z);
        PlayerPrefs.SetInt("CameraPosition", 0);
    }

    public void SaveNewPosition(int NewCameraPosition, Vector3 PositionPlayer) 
    {
        PlayerPrefs.SetFloat("X", PositionPlayer.x);
        PlayerPrefs.SetFloat("Y", PositionPlayer.y);
        PlayerPrefs.SetFloat("Z", PositionPlayer.z);

        Debug.Log(PositionPlayer);

        PlayerPrefs.SetInt("CameraPosition", NewCameraPosition + 1);
    }
}
