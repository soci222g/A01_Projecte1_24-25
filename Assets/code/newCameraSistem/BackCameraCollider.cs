using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCameraCollider : MonoBehaviour
{
    [SerializeField]
    private camerabehavior cam;

    private ColliderManager CollMan;
    private void Awake()
    {
        CollMan = GetComponentInParent<ColliderManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Player")
        {
            cam.setCurrenteRoom(-1);
            cam.SetSpawnPoint(-1);
            collision.gameObject.GetComponent<spikes>().SetSpawnPont(cam.GetSpawnPoint());

            CollMan.ActivateForward();
        }

    }
}
