using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarColliderTimer : MonoBehaviour
{

    private bool DeactivateCollider = false;

    private BoxCollider2D SelfCollider;
    [SerializeField]
    private float TimeNoCollider;
    [SerializeField]
    private float currentTime;


    private void Awake()
    {
        SelfCollider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (DeactivateCollider)
        {
            if (currentTime < TimeNoCollider)
            {
                currentTime += Time.deltaTime;
                SelfCollider.enabled = false;
            }
            else
            {
                DeactivateCollider = false;
            }
        }
        else {
            SelfCollider.enabled = true;
        }
    }



    public void StartDeactivateCollider()
    {
        DeactivateCollider = true;
        currentTime = 0;
    }
}

