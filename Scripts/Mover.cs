using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float xValue = 0;
    [SerializeField] float yValue = 0;
    [SerializeField] float zValue = 0;
    [SerializeField] float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if(SceneManagerScript.gameOver == false && CountdownText.beginGame == true && !FoundKeyLevel1.foundKey)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        xValue = -Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        zValue = -Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        //translate adds what you enter to the x,y,z values of the current position
        transform.Translate(xValue, yValue, zValue);
    }
}
