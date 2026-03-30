using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float spawnCooldown = 2.0f; // Time delay between spawns (in seconds)

    private float lastSpawnTime = -Mathf.Infinity; // Tracks when the last dog was spawned

    // Update is called once per frame
    void Update()
    {
        // Check if enough time has passed since the last spawn
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastSpawnTime >= spawnCooldown)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            lastSpawnTime = Time.time; // Update the last spawn time
        }
    }
}
