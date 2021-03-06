using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningScore : MonoBehaviour
{
    [SerializeField] GameObject scoreBox;
    [SerializeField] GameObject highScoreBox;
    public static float metersRun;

    // Start is called before the first frame update
    void Start()
    {
        metersRun = 0;
        highScoreBox.GetComponent<Text>().text = "Best: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore", 0f)).ToString() + " m";
        scoreBox.GetComponent<Text>().text = metersRun.ToString() + " m";
    }

    // Update is called once per frame
    void Update()
    {
        if(RunningSceneTracker.gameOver == false)
        {
            if(!PlayerMover.speedingNow)
            {
                metersRun += Time.deltaTime * 10f;
                scoreBox.GetComponent<Text>().text = Mathf.RoundToInt(metersRun).ToString() + " m";
            }
            else if (PlayerMover.speedingNow)
            {
                metersRun += Time.deltaTime * 20f;
                scoreBox.GetComponent<Text>().text = Mathf.RoundToInt(metersRun).ToString() + " m";
            }
            if (metersRun > PlayerPrefs.GetFloat("HighScore", 0f))
            {
                PlayerPrefs.SetFloat("HighScore", Mathf.RoundToInt(metersRun));
                highScoreBox.GetComponent<Text>().text = "Best: " + Mathf.RoundToInt(metersRun).ToString() + " m";
            }
        }

        
    }
}
