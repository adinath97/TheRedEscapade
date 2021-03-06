using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Text timerText;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(CountdownText.beginGame)
        {
            if (SceneManagerScript.gameOver == false && !FoundKeyLevel1.foundKey)
            {
                timer -= Time.deltaTime;
                timerText.text = Mathf.RoundToInt(timer).ToString();
            }

            if (timer <= 0 && SceneManagerScript.gameOver != true)
            {
                SceneManagerScript.gameOver = true;
            }
        }
    }
}
