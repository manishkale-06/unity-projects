using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject restartText;
    private SpawnManager spawnManagerScript;
    public bool gameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            restartText.SetActive(true);
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            gameOver = true;
        }
    }
    public void RestartGame()
    {
        restartText.SetActive(false);
        gameOver = false;
        spawnManagerScript.difficultyUI.SetActive(true);
    }
}
