using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20.0f;
    private float leftBound = -11.5f;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (gameObject.CompareTag("Obstacle") && transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
