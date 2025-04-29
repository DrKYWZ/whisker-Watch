using UnityEngine;
using UnityEngine.UI; 
public class CatAttributes : MonoBehaviour
{
    public int maxHealth = 5; // Health of the cat
    
    private int currentHealth;

    public GameObject gameOverPanel; // Reference to the game over panel
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        gameOverPanel.SetActive(false); // Hide the game over panel at the start
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the current health by the damage taken
        Debug.Log("Cat Health: " + currentHealth); // Log the current health to the console

        if (currentHealth <= 0)
        {
            GameOver(); // Call the GameOver method if health is zero or less
        }
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true); // Show the game over panel
        Time.timeScale = 0; // Pause the game
        Debug.Log("Game Over!"); // Log a message to the console
    }


}
