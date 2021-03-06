using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMover playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        //grab object with playerMover on it (ie. our player)
        playerMovement = GameObject.FindObjectOfType<PlayerMover>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerMovement.alive = false;
            RunningSceneTracker.gameOver = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
