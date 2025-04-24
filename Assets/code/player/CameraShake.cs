using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    [SerializeField] private Camera cam;
    

    private Vector3 cameraPosition;

    private float DurationTimer;
    [SerializeField]
    private float CurrentTime;

    private float ShakeForce;

    [SerializeField]
    private bool Activate;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = cam.transform.position;
    }

    private void Update()
    {
        if (Activate)
        {
            if (DurationTimer >= CurrentTime)
            {
                CurrentTime += Time.deltaTime;
                cam.transform.position = cameraPosition + Random.insideUnitSphere * ShakeForce;
            }
            else
            {
                CurrentTime = 0;
                Activate = false;
            }
        }
    }
    


    public void ShakeCamera(float Force, float Timer)
    {

        cameraPosition = cam.transform.position;

        DurationTimer = Timer;
        ShakeForce = Force;

        Activate = true;  
    }
}
