using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canon : MonoBehaviour
{

    private enum shootDir
    {
        Right,
        Left,
        Up,
        Down
    }

    [SerializeField] GameObject proj;
    [SerializeField] shootDir dir;
    [SerializeField] float speed;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        animator.speed = speed;
    }

    void shoot()
    {
        switch (dir)
        {
            case shootDir.Left:
                Instantiate(proj, this.transform.position - new Vector3(1, 0, -1), Quaternion.Euler(0, 0, 180));
                break;
            case shootDir.Right:
                Instantiate(proj, this.transform.position + new Vector3(1, 0, 1), Quaternion.Euler(0, 0, 0));
                break;
            case shootDir.Up:
                Instantiate(proj, this.transform.position + new Vector3(0, 1, 1), Quaternion.Euler(0, 0, 90));
                break;
            case shootDir.Down:
                Instantiate(proj, this.transform.position - new Vector3(0, 1, 1), Quaternion.Euler(0, 0, 270));
                break;
        }
    }
}
