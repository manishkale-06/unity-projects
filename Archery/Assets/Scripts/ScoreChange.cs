using TMPro;
using UnityEngine;


public class ScoreChange : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd/2;
        scoreText.text = "Score: " + score;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Arrow")) return;

        Collider hit = collision.GetContact(0).thisCollider;

        if (hit.CompareTag("Body"))
        {
            UpdateScore(20);
        }
        else if (hit.CompareTag("Head"))
        {
            UpdateScore(50);
        }
        else if (hit.CompareTag("Shield"))
        {
            UpdateScore(5);
        }
        
    }
}
