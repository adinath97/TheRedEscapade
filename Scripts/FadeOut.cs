using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fadeToBlack;
    bool fadeActivated;

    // Start is called before the first frame update
    void Start()
    {
        //initially, not visible
        fadeToBlack.canvasRenderer.SetAlpha(0.0f);
        fadeActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManagerScript.gameOver && !fadeActivated)
        {
            //activate once game is over
            fadeActivated = true;
            fadeToBlack.CrossFadeAlpha(1, 2, false);
        }
    }
}
