using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GroundDetector : MonoBehaviour
{
    [SerializeField]
    private bool groundDet;
    [SerializeField]
    private float DistansToGroudn = 0.85f;
    public LayerMask groundeMask;
    public List<Vector3> rays;

    private Fleep fleepSC;
    private Animator animator;
    // Start is called before the first frame update



    void Start()
    {
        fleepSC = GetComponent<Fleep>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GetectGround();
        fallingAnim();
    }

   private void GetectGround() {
        int count = 0;
    
        for (int i = 0; i < rays.Count; i++)
        {
            RaycastHit2D hit;
            Debug.DrawRay(transform.position + rays[i], transform.up * -1 * DistansToGroudn, Color.blue);
                if (fleepSC.GetFleepControler())
                {
                     hit = Physics2D.Raycast(transform.position + rays[i], transform.up * -1, DistansToGroudn, groundeMask);
                    Debug.DrawRay(transform.position + rays[i], transform.up * -1 * DistansToGroudn, Color.blue);
                }
                else
                {
                    hit = Physics2D.Raycast(transform.position + rays[i], transform.up * 1, DistansToGroudn, groundeMask);
                    Debug.DrawRay(transform.position + rays[i], transform.up * 1 * DistansToGroudn, Color.blue);
                }
            if(hit.collider != null)
            {
                count++;


            }

            if (hit.collider.tag == "movPlat")
            {
                transform.parent = hit.transform;
            }
            else
            {
                transform.parent = null;
            }

        }
        if(count > 0)
        {
            groundDet = true;
        }
        else
        {
            groundDet = false;
        }
   }

    private void fallingAnim()
    {
        if(GetGroundDetect() == false)
        {
            animator.SetBool("isFlying", true);
        }
        else
        {
            animator.SetBool("isFlying", false);
        }
    }

    public bool GetGroundDetect()
    {
        return groundDet;
    }
}
