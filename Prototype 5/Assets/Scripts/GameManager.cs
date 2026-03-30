using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.5f;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    private int score;
    public bool isGameActive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnRandomObject()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int idx = Random.Range(0, targets.Count);
            Instantiate(targets[idx]);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameeOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnRandomObject());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
}
