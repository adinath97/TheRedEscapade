using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        //follow player; maintain initial distance
        Vector3 targetPos = player.position + offset;
        transform.position = new Vector3(0, targetPos.y, targetPos.z);
    }
}
