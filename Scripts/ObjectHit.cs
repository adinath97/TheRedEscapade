using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public GameObject player;
    Rigidbody Rb;

    private void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        //if collision is with the player
        if(other.gameObject.tag == "Player")
        {
            //other is the object colliding with this (the object this script is on)
            player = other.gameObject;
            SceneManagerScript.gameOver = true;
            SceneManagerScript.playerLost = true;
            GetComponent<MeshRenderer>().material.color = Color.red;
            this.gameObject.tag = "Hit";
        }
    }

    private void Update()
    {
        /*
        if(this.tag == "Hit")
        {
            Vector3 relativePos = player.transform.position - transform.position;
            this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .05f);
        }
        */
    }
}
