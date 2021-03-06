using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static bool gameOver;
    public static bool playerLost;
    public static bool playerWon;
    public static bool levelOneComplete;
    [SerializeField] AudioClip levelOneCompleteSound;
    [SerializeField] [Range(0, 1)] float levelOneCompleteSoundVolume = .8f;
    [SerializeField] AudioClip levelOneLost;
    [SerializeField] [Range(0, 1)] float levelOneLostVolume = .8f;
    bool ringOnce;
    bool lossRingOnce;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerLost = false;
        playerWon = false;
        levelOneComplete = false;
        ringOnce = false;
        lossRingOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelOneComplete && !ringOnce)
        {
            //fade to white, go to intermediate win screen (done escaping, now run!)
            ringOnce = true;
            AudioSource.PlayClipAtPoint(levelOneCompleteSound, Camera.main.transform.position, levelOneCompleteSoundVolume);
            StartCoroutine(WaitAndLoadNextSceneRoutine());
        }

        if(RunningSceneTracker.gameOver && RunningSceneTracker.counter == 0)
        {
            RunningSceneTracker.counter++;
            StartCoroutine(WaitAndLoadNextSceneRoutineTwo());
        }

        if(gameOver && !levelOneComplete && !lossRingOnce)
        {
            lossRingOnce = true;
            AudioSource.PlayClipAtPoint(levelOneLost, Camera.main.transform.position, levelOneLostVolume);
            StartCoroutine(WaitAndLoadNextSceneRoutineThree());
        }
    }

    IEnumerator WaitAndLoadNextSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TransitionScene");
    }

    IEnumerator WaitAndLoadNextSceneRoutineTwo()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RunGameOver");
    }

    IEnumerator WaitAndLoadNextSceneRoutineThree()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("JailEscapeOver");
    }

    public void Play()
    {
        FoundKeyLevel1.foundKey = false;
        RunningSceneTracker.gameOver = false;
        RunningSceneTracker.counter = 0;
        SceneManager.LoadScene("JailEscapePreview");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadEscapeScene()
    {
        SceneManager.LoadScene("JailEscapeScene");
    }

    public void LoadRunScene()
    {
        RunningSceneTracker.gameOver = false;
        RunningSceneTracker.counter = 0;
        SceneManager.LoadScene("RunningScene");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
