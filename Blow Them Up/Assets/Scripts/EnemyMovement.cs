using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameOver gameOverScript;
    

    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScript = GameObject.Find("Boundry").GetComponent<GameOver>();
        speed *= DifficutyButton.selectedDifficulty; 
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (gameOverScript.gameOver)
        {
            ClearObjectsWithTag("Target");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Game Over");

        }
    }
     void ClearObjectsWithTag(string tag)
    {
        GameObject[] objectsToClear = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsToClear)
        {
            Destroy(obj);
        }
    }
}
