using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    [SerializeField] float timeLimit = 3f;
    float counter;

    Quaternion targetAngle_0 = Quaternion.Euler(0, 360, 0);
    Quaternion targetAngle_180 = Quaternion.Euler(0, 180, 0);
    Quaternion currentAngle;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        currentAngle = targetAngle_0;
    }

    // Update is called once per frame
    void Update()
    {
        if(CountdownText.beginGame == true)
        {
            counter += Time.deltaTime;
            if (counter > timeLimit)
            {
                //rotate smoothly
                counter = 0;
                ChangeCurrentAngle();
                //transform.Rotate(0,180,0);
            }

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, currentAngle, .01f);
        }
    }

    void ChangeCurrentAngle()
    {
        if(currentAngle.eulerAngles.y == targetAngle_0.eulerAngles.y)
        {
            currentAngle = targetAngle_180;
        }
        else
        {
            currentAngle = targetAngle_0;
        }
    }
}
