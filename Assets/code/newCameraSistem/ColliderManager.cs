using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
   
     private GameObject SelfcolliderForward;
     private GameObject SelfColliderBackwards;

    [Header("next Collider")]
    [SerializeField] private GameObject NextParent;

                       private GameObject NextColliderForward;
                       private GameObject NextColliderBackwards;

    [Header("Back Collider")]
    [SerializeField] private GameObject BackParent;

    private GameObject BackColliderForward;
    private GameObject BackColliderBackwards;

    [SerializeField] private GameObject DefoultCollider;

    private void Awake()
    {
        //referencia de los sigientes colliders
        if (NextParent.GetComponentInChildren<ForwardCollider>() != null)
            NextColliderForward = NextParent.GetComponentInChildren<ForwardCollider>().gameObject;
        else
            NextColliderForward = DefoultCollider;


        if (NextParent.GetComponentInChildren<BackCameraCollider>() != null)
            NextColliderBackwards = NextParent.GetComponentInChildren<BackCameraCollider>().gameObject;
        else
            NextColliderBackwards = DefoultCollider;


        //referencia a los anteriores colliders
        if (BackParent.GetComponentInChildren<ForwardCollider>() != null)
            BackColliderForward = BackParent.GetComponentInChildren<ForwardCollider>().gameObject;
        else
            BackColliderForward = DefoultCollider;


        if (BackParent.GetComponentInChildren<BackCameraCollider>() != null)
            BackColliderBackwards = BackParent.GetComponentInChildren<BackCameraCollider>().gameObject;
        else
            BackColliderBackwards = DefoultCollider;

       //referencia a tus pripios colliders
        if( GetComponentInChildren<ForwardCollider>() != null)
        SelfcolliderForward = GetComponentInChildren<ForwardCollider>().gameObject;
        else
            SelfcolliderForward = DefoultCollider;
        if (GetComponentInChildren<BackCameraCollider>() != null)
            SelfColliderBackwards = GetComponentInChildren<BackCameraCollider>().gameObject;
        else
            SelfColliderBackwards = DefoultCollider;







        SelfcolliderForward.SetActive(false);
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


        NextColliderForward.SetActive(false);
        NextColliderBackwards.SetActive(false);

        BackColliderForward.SetActive(true);
        BackColliderBackwards.SetActive(true);
    }
}
