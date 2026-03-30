using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    private float RangeonX = 20.0f;
    private int zSpawn = 25;
    private float startDelay = 2.0f;
    private float spawnDelay = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-RangeonX, RangeonX), 0, zSpawn);
        Instantiate(animalPrefab[animalIndex], spawnPos, animalPrefab[animalIndex].transform.rotation);
    }
}
