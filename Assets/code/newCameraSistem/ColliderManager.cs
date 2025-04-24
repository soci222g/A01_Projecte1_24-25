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

    [SerializeField] private GameObject DefoultCollider;

    private void Awake()
    {
        if (NextColliderForward == null)
        {
            NextColliderForward = DefoultCollider;
        }
        if (NextColliderBackwards == null)
        {
            NextColliderBackwards = DefoultCollider;  
        }
        if (BackColliderForward == null)
        {
            BackColliderForward = DefoultCollider;
        }
        if (BackColliderBackwards == null)
        {
            BackColliderBackwards = DefoultCollider;
        }

        if (SelfcolliderForward == null)
            SelfcolliderForward = DefoultCollider;
        if (SelfColliderBackwards == null)
            SelfColliderBackwards = DefoultCollider;

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
