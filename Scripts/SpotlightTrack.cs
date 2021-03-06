using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTrack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Found Trigger!");
            SceneManagerScript.gameOver = true;
            SceneManagerScript.playerLost = true;
        }
    }
}
