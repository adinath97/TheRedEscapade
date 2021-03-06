using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;
    bool spawnPowerUp;
    bool spawnPowerUpTwo;
    float timerUpperLimit;
    float timerUpperLimitTwo;
    float timer;
    float timerTwo;

    //idea: instantiate a groundTile, then instantiate another one at the nextSpawnpoint of the first, then keep on going!

    // Start is called before the first frame update
    void Start()
    {
        spawnPowerUp = false;
        timerUpperLimit = Random.Range(10, 20);
        timer = 0;
        for (int i = 0; i < 20; i++)
        {
            if(i < 5)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerUpperLimit)
        {
            timerUpperLimit = Random.Range(12, 25);
            timer = 0;
            spawnPowerUp = true;
        }
    }

    public void SpawnTile(bool spawnNow)
    {
        //instantiate a tile
        GameObject tempTile = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity) as GameObject;
        //obtain the next spawn point, the transform of a child of the tempTile
        nextSpawnPoint = tempTile.transform.GetChild(1).transform.position;

        if(spawnNow)
        {
            tempTile.GetComponent<NewTileSpawner>().SpawnObstacles();
        }

        if(spawnPowerUp)
        {
            spawnPowerUp = false;
            tempTile.GetComponent<NewTileSpawner>().SpawnPowerUp();
        }
    }
}
