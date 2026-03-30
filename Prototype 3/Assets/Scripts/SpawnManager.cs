
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 2;
    private float spawnDelay = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    }
}

