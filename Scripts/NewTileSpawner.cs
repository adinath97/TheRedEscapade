using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTileSpawner : MonoBehaviour
{
    SpawnGround groundSpawner;
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] List<GameObject> powerUps = new List<GameObject>();
    float obstacle1Precence, obstacle2Precence, obstacle3Precence, obstacle4Precence;
    int valuesSelected = 0;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<SpawnGround>();
        obstacle1Precence = 100;
        obstacle2Precence = 200;
        obstacle3Precence = 300;
    }

    private void OnTriggerExit(Collider other)
    {
        //track objects exciting the trigger
        groundSpawner.SpawnTile(true);
        Destroy(this.gameObject, 2f);
    }

    public void SpawnObstacles()
    {
        if(RunningScore.metersRun <= 100 && RunningScore.metersRun >= 0)
        {
            //pick an obstacle out of the list of obstacles
            GameObject currentObstacle;
            int randomObstacle = Random.Range(0, 1);
            currentObstacle = obstacles[randomObstacle];

            //pick spawnpoint randomly, then spawn an object there
            int randomObstacleSpot = Random.Range(2, 5);
            Transform spawnPoint = this.transform.GetChild(randomObstacleSpot).transform;

            Instantiate(currentObstacle, spawnPoint.position, Quaternion.identity, transform);
        }

        else if (RunningScore.metersRun > 100 && RunningScore.metersRun <= 200)
        {

            //pick an obstacle out of the list of obstacles
            GameObject currentObstacle;
            int randomObstacle = Random.Range(0, 2);
            currentObstacle = obstacles[randomObstacle];

            //pick spawnpoint randomly, then spawn an object there
            int randomObstacleSpot = Random.Range(2, 5);
            Transform spawnPoint = this.transform.GetChild(randomObstacleSpot).transform;

            Instantiate(currentObstacle, spawnPoint.position, Quaternion.identity, transform);
        }

        else if (RunningScore.metersRun > 200 && RunningScore.metersRun <= 300)
        {
            //pick an obstacle out of the list of obstacles
            GameObject currentObstacle;
            int randomObstacle = Random.Range(0, 3);
            currentObstacle = obstacles[randomObstacle];

            //pick spawnpoint randomly, then spawn an object there
            int randomObstacleSpot = Random.Range(2, 5);
            Transform spawnPoint = this.transform.GetChild(randomObstacleSpot).transform;

            Instantiate(currentObstacle, spawnPoint.position, Quaternion.identity, transform);
        }

        else if (RunningScore.metersRun > 300)
        {
            //pick an obstacle out of the list of obstacles
            GameObject currentObstacle;
            int randomObstacle = Random.Range(0, obstacles.Count);
            currentObstacle = obstacles[randomObstacle];

            //pick spawnpoint randomly, then spawn an object there
            int randomObstacleSpot = Random.Range(2, 5);
            Transform spawnPoint = this.transform.GetChild(randomObstacleSpot).transform;

            Instantiate(currentObstacle, spawnPoint.position, Quaternion.identity, transform);
        }

    }

    public void SpawnPowerUp()
    {
        //pick a power up out of the list of power ups
        GameObject currentPowerUp;
        int randomPowerUp = Random.Range(0, 2);
        currentPowerUp = powerUps[randomPowerUp];

        //pick spawnpoint randomly, then spawn an object there
        int randomPowerUpSpot = Random.Range(5, 8);
        Transform spawnPoint = this.transform.GetChild(randomPowerUpSpot).transform;

        Instantiate(currentPowerUp, spawnPoint.position, Quaternion.identity, transform);
    }
}
