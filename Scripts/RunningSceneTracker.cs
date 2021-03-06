using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSceneTracker : MonoBehaviour
{
    public static bool gameOver;
    public static int counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
