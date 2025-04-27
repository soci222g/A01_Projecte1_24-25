using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleLogic : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField]
    private Animator animator;

    void Start()
    {
        
    }


    void Update()
    {
        
    }


    void spawnArrow()
    {
        Instantiate(arrow, transform.position - new Vector3(-0.5f, 0.37f, 0), transform.rotation);
    }
}
