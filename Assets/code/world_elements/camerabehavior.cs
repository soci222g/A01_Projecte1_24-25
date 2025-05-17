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
    public List<Transform> SpawnPoints;

    private int spawnPointNum;
    [SerializeField]
    private int roomToGo;
    [SerializeField]
    private int currentRoom;


    [SerializeField]
    private Vector2 safeVelocity;

    [SerializeField]
    private GameObject player;

    private atack Atack;

    // Start is called before the first frame update
    void Start()
    {
        spawnPointNum = 0;
        roomToGo = 0;
        currentRoom = 0;
        camera.transform.position = cameraPosition[0].position;
        cameraPosition[0].GetComponent<ColliderManager>().ActivateSelf();

        Atack = player.GetComponentInChildren<atack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentRoom != roomToGo)
        {

            
            cameraPosition[roomToGo].GetComponent<ColliderManager>().ActivateSelf();
            Vector3 dir = cameraPosition[roomToGo].position - camera.transform.position;
            float distence = dir.magnitude;
            dir.Normalize();
            

            camera.transform.position += dir * speed * Time.deltaTime;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(player.GetComponent<Rigidbody2D>().velocity.x, 0);
            player.GetComponent<movement>().enabled = false;
            // Time.timeScale = 0;  pause time (para el pause menu)
            Atack.enabled = false;
            if (distence < 1f)
            {
                camera.transform.position = cameraPosition[roomToGo].position;
                currentRoom = roomToGo;

                player.GetComponent<Rigidbody2D>().velocity = safeVelocity;
                player.GetComponent<movement>().enabled = true;
                Atack.enabled = true;
            }
        }
       

    }

    public void SetSpawnPoint(int num)
    {
        spawnPointNum += num;
    }

    public Transform GetSpawnPoint()
    {
        return SpawnPoints[spawnPointNum];
    }

    public void setCurrenteRoom(int num)
    {
        roomToGo += num;
    }

    public void Safe_Velocity(Vector2 velocity)
    {
        safeVelocity = velocity;
    }

    public int getCurrentRoom()
    {
        return currentRoom;
    }


}
