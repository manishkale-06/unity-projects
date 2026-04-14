using System;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{

    public bool hasStarted = false;
    public Canvas gameMenu;
    public Canvas crossHair;
    private ScoreChange score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = GameObject.Find("DummyTarget").GetComponent<ScoreChange>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStarted()
    {
        hasStarted = true;
        gameMenu.gameObject.SetActive(false);
        crossHair.gameObject.SetActive(true);
        score.UpdateScore(0);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
