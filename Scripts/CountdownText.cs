using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    public GameObject startText;
    float timer = 3f;
    public static bool beginGame;
    bool startedCoroutine;


    // Start is called before the first frame update
    void Start()
    {
        beginGame = false;
        startedCoroutine = false;
        startText.gameObject.SetActive(true);
        startText.GetComponent<Text>().text = "READY";
        startText.GetComponent<Text>().color = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        if (!startedCoroutine)
        {
            startedCoroutine = true;
            StartCoroutine(CountDownAndLoadRoutine());
        }
    }

    IEnumerator CountDownAndLoadRoutine()
    {
        yield return new WaitForSeconds(1f);

        startText.GetComponent<Text>().text = "STEADY";
        startText.GetComponent<Text>().color = Color.yellow;
        yield return new WaitForSeconds(1f);

        startText.GetComponent<Text>().text = "ESCAPE!";
        startText.GetComponent<Text>().color = Color.green;
        yield return new WaitForSeconds(1f);

        startText.gameObject.SetActive(false);
        beginGame = true;
    }
}
