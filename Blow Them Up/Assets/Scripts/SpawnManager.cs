using UnityEngine;
using System.Collections;
using TMPro;


public class SpawnManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject[] targets;
    public GameObject ball;
    public GameObject cannon;
    public GameObject rangePrefab;
    public GameObject difficultyUI;
    private GameOver gameOverScript;

    public int counter;
    public float waitTime = 3.0f;
    public bool Spawned = true;
    public bool isBallSpawned = false;
    private GameObject ballSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameOverScript = GameObject.Find("Boundry").GetComponent<GameOver>();
    }

    IEnumerator SpawnDelay()
    {
        while (!gameOverScript.gameOver)
        {
            yield return new WaitForSeconds(waitTime);
            SpawnTarget();
            isBallSpawned = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPos = cannon.transform.position + new Vector3(0, 4, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isBallSpawned)
        {
            isBallSpawned = true;
            ballSpawn = Instantiate(ball, spawnPos, ball.transform.rotation);
            ballSpawn.AddComponent<Projectile>();


        }

    }
    public void Counter(int count)
    {
        counter += count;
        scoreText.text = "Score: " + counter;
    }

    void SpawnTarget()
    {
        int targetIdx = Random.Range(0, targets.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-27, 27), 0.5f, 130);
        Instantiate(targets[targetIdx], spawnPos, targets[targetIdx].transform.rotation);
    }
    public void StartGame()
    {
        counter = 0;
        StopAllCoroutines();
        Counter(0);
        StartCoroutine(SpawnDelay());
        difficultyUI.SetActive(false);
    }

    
}
