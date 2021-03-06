using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningTextManager : MonoBehaviour
{
    public GameObject goodLuckText;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        goodLuckText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitAndEraseRoutine());
    }

    IEnumerator WaitAndEraseRoutine()
    {
        yield return new WaitForSeconds(2f);
        goodLuckText.SetActive(false);
    }
}
