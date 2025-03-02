using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerabehavior : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private int ROOM_COUNTER;

    public List<Transform> cameraPosition;

    private int currentRoom;
    
    // Start is called before the first frame update
    void Start()
    {
        currentRoom = 0;
        camera.transform.position = cameraPosition[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void setCurrenteRoom(int num)
    {
        currentRoom += num;
    }
}
