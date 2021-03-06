using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToWhiteLevelOne : MonoBehaviour
{
    public Image fadeToWhite;
    bool fadeActivated;

    // Start is called before the first frame update
    void Start()
    {
        //initially, not visible
        fadeToWhite.canvasRenderer.SetAlpha(0.0f);
        fadeActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManagerScript.levelOneComplete && !fadeActivated)
        {
            //activate once game is over
            fadeActivated = true;
            fadeToWhite.CrossFadeAlpha(1, 2, false);
        }
    }
}
