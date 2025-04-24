using UnityEngine;

public class MosquitoSigma : MonoBehaviour
{
    public int clickHealth = 10; // Health of the mosquito
    public int currentClicks = 0; // Number of clicks on the mosquito


    void OnMouseDown()
    {
        currentClicks++; // Decrease the health of the mosquito when clicked
        Debug.Log("Mosquito Sigma clicked! Health: " + clickHealth); // Log the health of the mosquito to the console

        if (currentClicks >= clickHealth) // Check if the health is less than or equal to 0
        {
            Destroy(gameObject); // Destroy the mosquito
            Debug.Log("Mosquito Sigma destroyed!"); // Log a message to the console
        }
    }

}
