using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Rigidbody myRigidbody;
    [SerializeField] float timeLimit = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //we initially want the object invisible
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeLimit)
        {
            meshRenderer.enabled = true;
            myRigidbody.useGravity = true;
        }
    }
}
