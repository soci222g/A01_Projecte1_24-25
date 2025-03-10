using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionState : MonoBehaviour
{

    [SerializeField] bool canAct;

    // Start is called before the first frame update
    void Start()
    {
        canAct = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAction()
    {
        canAct = false;
    }

    public void endAction()
    {
        canAct = true;
    }

    public bool getActionState()
    {
        return canAct;
    }

}
