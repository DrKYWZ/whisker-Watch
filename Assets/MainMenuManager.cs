using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.UI; // Import the Unity UI namespace
using UnityEngine.SceneManagement; // Import the SceneManagement namespace
using System.Collections; // Import the Collections namespace

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Reference to the play button GameObject
    public GameObject gameView; // Reference to the credits menu GameObject


    public void StartGame()
    {
        mainMenuPanel.SetActive(false); // Hide the main menu panel
        gameView.SetActive(true); // Show the game view panel
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Game is quitting..."); // Log a message to the console
    }

}
