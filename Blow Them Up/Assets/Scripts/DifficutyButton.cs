using UnityEngine;
using UnityEngine.UI;

public class DifficutyButton : MonoBehaviour
{
    public int difficulty;
    public SpawnManager spawnManager;
    
    public Button button;
    public static int selectedDifficulty;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficuty);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetDifficuty()
    {
        selectedDifficulty = difficulty;
        spawnManager.StartGame();
    }
}
