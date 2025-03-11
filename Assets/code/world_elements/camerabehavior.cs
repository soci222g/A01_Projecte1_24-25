using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camerabehavior : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private int speed;


    public List<Transform> cameraPosition;

    private int roomToGo;

    private int currentRoom;
    
    // Start is called before the first frame update
    void Start()
    {

        roomToGo = 0;
        currentRoom = 0;
        camera.transform.position = cameraPosition[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoom != roomToGo)
        {
            Vector3 dir = cameraPosition[roomToGo].position - camera.transform.position;
            float distence = dir.magnitude;
            dir.Normalize();

            camera.transform.position += dir * speed * Time.deltaTime;
            if (distence < 0.1f)
            {
                currentRoom = roomToGo;
            }
        }
       

    }

    public void setCurrenteRoom(int num)
    {
        roomToGo += num;
    }
}
