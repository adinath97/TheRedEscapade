using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        int randomSelection = Random.Range(0, 2);
        if (randomSelection == 1) moveSpeed = 0.05f;
        if (randomSelection == 0) moveSpeed = -0.05f;
        transform.position = new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0, 0);

        //raycast to detect wall on right
        var ray = new Ray(this.transform.position, this.transform.right);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1f))
        {
            if (hitInfo.collider.tag == "Wall")
            {
                moveSpeed = -moveSpeed;
            }
        }

        //raycast to detect wall on left
        var ray2 = new Ray(this.transform.position, -this.transform.right);
        RaycastHit hitInfo2;
        if (Physics.Raycast(ray2, out hitInfo2, 1f))
        {
            if (hitInfo2.collider.tag == "Wall")
            {
                moveSpeed = -moveSpeed;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //make player invisible
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            PlayerMover.speedingNow = true;
            PlayerMover.speedBoostTimer = 0;
            Destroy(this.gameObject);
        }
    }
}
