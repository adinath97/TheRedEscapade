using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    float moveSpeed;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = .01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0);

        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, this.transform.right);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 1.5f))
        {
            if(hitInfo.collider.tag == "Wall")
            {
                moveSpeed = 0;
            }
        }
        /*
        //raycast to detect wall on left
        var ray2 = new Ray(this.transform.position, -this.transform.right);
        RaycastHit hitInfo2;
        if (Physics.Raycast(ray2, out hitInfo2, 1.5f))
        {
            if (hitInfo2.collider.tag == "Wall")
            {
                moveSpeed = 0;
            }
        }
        */
    }
}
