using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public bool alive = true;
    public float speed;
    public float horizonalMovementSpeed;
    [SerializeField] Rigidbody myRigidbody;
    float moveSideways;
    bool checkNow;
    public static bool invisibleNow;
    public static bool speedingNow;
    float invisibleTimerLimit;
    float speedBoostTimerLimit;
    public static float invisibleTimer;
    public static float speedBoostTimer;
    Vector3 limitingPositions;
    float xMin, xMax;
    [SerializeField] AudioClip hitSound;
    [SerializeField] [Range(0,1)] float hitVolume = .6f;
    [SerializeField] AudioClip powerUpSound;
    [SerializeField] [Range(0, 1)] float powerUpVolume = .6f;


    private void Start()
    {
        invisibleNow = false;
        speedingNow = false;
        invisibleTimerLimit = 10f;
        speedBoostTimerLimit = 10f;
        invisibleTimer = 0;
        speedBoostTimer = 0;
        speed = 27f;
        horizonalMovementSpeed = 15f;
        checkNow = true;
        limitingPositions = transform.position;
        xMin = transform.position.x - 4.5f;
        xMax = transform.position.x + 4.5f;
    }

    private void FixedUpdate()
    {
        if(!alive)
        {
            return;
        }

        if(!speedingNow)
        {
            //move forward at a certain rate, and update the rigidbody
            Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMovement = transform.right * moveSideways * horizonalMovementSpeed * Time.fixedDeltaTime;
            Vector3 preFinalPos = myRigidbody.position + horizontalMovement + moveForward;
            float finalXPos = Mathf.Clamp(preFinalPos.x, xMin, xMax);
            Vector3 finalPos = new Vector3(finalXPos, preFinalPos.y, preFinalPos.z);
            myRigidbody.MovePosition(finalPos);
        }
        if(speedingNow)
        {
            //move forward at a certain rate, and update the rigidbody
            Vector3 moveForward = transform.forward * speed * 2f * Time.fixedDeltaTime;
            Vector3 horizontalMovement = transform.right * moveSideways * horizonalMovementSpeed * Time.fixedDeltaTime;
            Vector3 preFinalPos = myRigidbody.position + horizontalMovement + moveForward;
            float finalXPos = Mathf.Clamp(preFinalPos.x, xMin, xMax);
            Vector3 finalPos = new Vector3(finalXPos, preFinalPos.y, preFinalPos.z);
            myRigidbody.MovePosition(finalPos);
        }
        

        if(this.GetComponent<BoxCollider>().isTrigger)
        {
            if(invisibleNow)
            {
                invisibleTimer += Time.deltaTime;
                if (invisibleTimer >= 9f && invisibleTimer < invisibleTimerLimit && !speedingNow)
                {
                    if (invisibleTimer >= 9f && invisibleTimer < 9.2f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (invisibleTimer >= 9.2f && invisibleTimer < 9.4f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    }
                    else if (invisibleTimer >= 9.4f && invisibleTimer < 9.6f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (invisibleTimer >= 9.6f && invisibleTimer < 9.8f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    }
                    else if (invisibleTimer >= 9.8f && invisibleTimer < 9.9f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (invisibleTimer >= 9.9f && invisibleTimer < 10f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    }
                }
                if (invisibleTimer >= invisibleTimerLimit)
                {
                    if(!speedingNow)
                    {
                        this.GetComponent<BoxCollider>().isTrigger = false;
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    invisibleTimer = 0;
                    invisibleNow = false;
                }
            }
            if (speedingNow)
            {
                speedBoostTimer += Time.deltaTime;
                if (speedBoostTimer >= 9f && speedBoostTimer < speedBoostTimerLimit && !invisibleNow)
                {
                    if (speedBoostTimer >= 9f && speedBoostTimer < 9.2f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (speedBoostTimer >= 9.2f && speedBoostTimer < 9.4f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.gray;
                    }
                    else if (speedBoostTimer >= 9.4f && speedBoostTimer < 9.6f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (speedBoostTimer >= 9.6f && speedBoostTimer < 9.8f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.gray;
                    }
                    else if (speedBoostTimer >= 9.8f && speedBoostTimer < 9.9f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    else if (speedBoostTimer >= 9.9f && speedBoostTimer < 10f)
                    {
                        this.GetComponent<MeshRenderer>().material.color = Color.gray;
                    }
                }
                if (speedBoostTimer >= speedBoostTimerLimit)
                {
                    if(!invisibleNow)
                    {
                        this.GetComponent<BoxCollider>().isTrigger = false;
                        this.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                    speedBoostTimer = 0;
                    speedingNow = false;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        moveSideways = Input.GetAxis("Horizontal");

        if(checkNow && Mathf.RoundToInt((RunningScore.metersRun * 10f)) != 0)
        {
            if (Mathf.RoundToInt((RunningScore.metersRun * 10f)) % 50 == 0)
            {
                checkNow = false;
                speed += .5f;
                horizonalMovementSpeed += .25f;
                StartCoroutine(WaitAndRecheckRoutine());
            }
        }
    }

    private IEnumerator WaitAndRecheckRoutine()
    {
        yield return new WaitForSeconds(2f);
        checkNow = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            //player loses
            AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position, hitVolume);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            AudioSource.PlayClipAtPoint(powerUpSound, Camera.main.transform.position, powerUpVolume);
        }
    }
}
