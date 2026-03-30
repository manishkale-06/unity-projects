using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnDelay = 3.0f;
    

    private int ballIndexstart = 0;
    private int ballIndexEnd = 2;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("SpawnRandomBall", startDelay, spawnDelay);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        spawnDelay = Random.Range(6.0f, 10.0f);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[Random.Range(ballIndexstart, ballIndexEnd + 1)], spawnPos, ballPrefabs[Random.Range(ballIndexstart, ballIndexEnd + 1)].transform.rotation);

        
        
    }

}
