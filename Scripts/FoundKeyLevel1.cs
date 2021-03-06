using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundKeyLevel1 : MonoBehaviour
{
    public static bool foundKey;

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Player")
        {
            foundKey = true;
            SceneManagerScript.levelOneComplete = true;
        }
    }
}
