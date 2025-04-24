using System.Collections;
using UnityEngine;
using TMPro; 
using System.Collections.Generic; 

public class MosquitoSpawner : MonoBehaviour
{
    public GameObject mosquitoPrefabL; // Prefab of the mosquito to spawn
    public GameObject mosquitoPrefabR; // Prefab of the mosquito to spawn
    public GameObject mosquitoSigma; // Prefab of the mosquito to spawn
    public Transform leftSpawnPoint; // Left spawn point
    public Transform rightSpawnPoint; // Right spawn point
    public float spawnInterval = 2f; // Time interval between spawns
    public float waveDuration = 5f;// Start is called once before the first execution of Update after the MonoBehaviour is created
    public int waveNumber = 5; // Number of waves to spawn
    public TextMeshProUGUI waveCountText; // UI text to display the wave count



    private bool spawning = false;
    private bool isGameOver = false; // Flag to check if the game is over
    private bool isWaitingForRestart = false;


    
    void Start()
    {
        StartCoroutine(StartWaves()); // Start the coroutine to spawn waves of mosquitoes
    }

    void Update()
    {
        waveCountText.text = "Wave: " + waveNumber.ToString(); // Update the UI text with the current wave number

        if (isGameOver && !isWaitingForRestart) // Check if the game is over and not waiting for restart
        {
            isWaitingForRestart = true; // Set the waiting flag to true
            RestartWaves(); // Call the method to restart the waves
        }
    }

    IEnumerator StartWaves()
    {
        spawning = true; // Set the spawning flag to true
        float timer = 0f; // Initialize the timer
        
        SpawnMosquitoSigma(); // Spawn the mosquito sigma at the start of the wave

        while (timer < waveDuration)
        {
            SpawnMosquito(); // Call the method to spawn a mosquito
            yield return new WaitForSeconds(spawnInterval); // Wait for the next frame
            timer += spawnInterval; // Increment the timer by the spawn interval
        }

        if (waveNumber >= 7) // Check if the wave number is 10
        {
            isGameOver = true;
            Debug.Log("Wave Ended");
            yield break;
        }

        spawning = false; // Set the spawning flag to false
        waveNumber++;

        yield return new WaitForSeconds(1f); // Wait for 1 second before starting the next wave
        StartCoroutine(StartWaves()); // Start the coroutine to spawn waves of mosquitoes again

    }

    public void RestartWaves()
    {
        StopAllCoroutines(); // Stop all coroutines
        waveNumber = 1;
        isGameOver = true;
        StartCoroutine(StartWaves()); // Start the coroutine to spawn waves of mosquitoes again
    }

    void SpawnMosquito()
    {
        // Generate a random position within the spawn radius
        GameObject mosquitoLeft = Instantiate(mosquitoPrefabL, leftSpawnPoint.position, Quaternion.identity); // Instantiate the mosquito prefab at the spawn point with no rotation
        mosquitoLeft.transform.localScale = new Vector3(1, 1, 1); // Flip the mosquito to face left


        GameObject mosquitoRight = Instantiate(mosquitoPrefabR, rightSpawnPoint.position, Quaternion.identity); // Instantiate the mosquito prefab at the spawn point with no rotation
        mosquitoRight.transform.localScale = new Vector3(-1, 1, 1);

    }

    void SpawnMosquitoSigma()
    {
        GameObject mosquito = Instantiate(mosquitoSigma, leftSpawnPoint.position, Quaternion.identity); // Instantiate the mosquito prefab at the spawn point with no rotation
        mosquito.transform.localScale = new Vector3(1, 1, 1); // Flip the mosquito to face left
    }
}