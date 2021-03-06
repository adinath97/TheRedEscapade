using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add xAngle,yAngle,zAngle to current rotation x,y,z values every frame
        xAngle = 0;
        yAngle = 50 * Time.deltaTime;
        zAngle = 0;
        transform.Rotate(xAngle,yAngle,zAngle);
    }
}
