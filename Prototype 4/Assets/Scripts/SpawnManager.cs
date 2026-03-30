using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    private int waveNumber = 1;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWaves(waveNumber);
         Instantiate(powerupPrefab, GenerateRandomPosition() , powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
            Instantiate(powerupPrefab, GenerateRandomPosition() , powerupPrefab.transform.rotation);
        }
    }
    void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPosition() , enemyPrefab.transform.rotation);
        }
    }
    private Vector3 GenerateRandomPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx, 0, spawnPosz);

        return randomPos;
    }
}
