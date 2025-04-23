using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [Header("selfCollider")]
    [SerializeField] private GameObject SelfcolliderForward;
    [SerializeField] private GameObject SelfColliderBackwards;

    [Header("next Collider")]
    [SerializeField] private GameObject NextColliderForward;
    [SerializeField] private GameObject NextColliderBackwards;

    [Header("Back Collider")]
    [SerializeField] private GameObject BackColliderForward;
    [SerializeField] private GameObject BackColliderBackwards;





    private void Awake()
    {
        if (SelfcolliderForward != null)
            SelfcolliderForward.SetActive(false);
        if(SelfColliderBackwards != null)
            SelfColliderBackwards.SetActive(false);


    }

    public void ActivateSelf()
    {
        if (SelfcolliderForward != null)
            SelfcolliderForward.SetActive(true);
        if (SelfColliderBackwards != null)
            SelfColliderBackwards.SetActive(true);
    }
    public void ActivateForward()
    {
        if (SelfcolliderForward != null)
            SelfcolliderForward.SetActive(false);
        if (SelfColliderBackwards != null)
            SelfColliderBackwards.SetActive(false);


        NextColliderForward.SetActive(true);
        NextColliderBackwards.SetActive(true);
        
    }
    public void ActivateBack()
    {
        if (SelfcolliderForward != null)
            SelfcolliderForward.SetActive(false);
        if (SelfColliderBackwards != null)
            SelfColliderBackwards.SetActive(false); 


            BackColliderForward.SetActive(true);
            BackColliderBackwards.SetActive(true);
    }
}
