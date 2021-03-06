using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackerRunGameOver : MonoBehaviour
{
    public GameObject currentScore;
    public GameObject highScore;

    // Start is called before the first frame update
    void Start()
    {
        currentScore.GetComponent<Text>().text = "DISTANCE: " + Mathf.RoundToInt(RunningScore.metersRun).ToString() + " m";
        highScore.GetComponent<Text>().text = "BEST: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("HighScore", 0f)).ToString() + " m";
    }
}
