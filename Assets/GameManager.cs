using UnityEngine;
using UnityEngine.UI; 
using TMPro; 


public class GameManager : MonoBehaviour

{
    public static GameManager instance; // Singleton instance of GameManager
    public bool gameStarted = false;
    public GameObject timerPanel;

    void Awake()
    {
        instance = this;
        Time.timeScale = 0f; 
    }

    public void StartGame()
    {
        gameStarted = true;
        Time.timeScale = 1f; 

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true; // Hides the cursor when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
