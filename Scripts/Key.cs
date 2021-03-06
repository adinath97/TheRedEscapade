using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            SceneManagerScript.gameOver = true;
            SceneManagerScript.playerWon = true;
        }
    }
}
