using UnityEngine;

public class MosquitoMov : MonoBehaviour
{
    private MosquitoSpawner mosquitoSpawner;
    public float speed = 5f; 
    public float waveFrequency = 1f; // Frequency of the wave motion
    public float waveMagnitude = 0.5f; // Magnitude of the wave motion

    private Transform target; // Target transform for the mosquito to move towards
    private Vector2 moveDirection; // Direction of movement for the mosquito
    private Vector2 perpedicular; 
    private float timeOffset;
    private bool isClicked = false; // Flag to check if the mosquito is clicked

void Start()
{
    mosquitoSpawner = GameObject.Find("MosquitoSpawner").GetComponent<MosquitoSpawner>();
    speed = speed * mosquitoSpawner.difficultySpeed;
    target = GameObject.FindGameObjectWithTag("Cat").transform; // Find the cat object in the scene
    Vector2 dir = target.position - transform.position; // Calculate the direction to the target
    moveDirection = dir.normalized; // Normalize the direction vector

    perpedicular = new Vector2(-moveDirection.y, moveDirection.x); // Calculate the perpendicular direction for wave motion
    timeOffset = Random.Range(0f, 2f * Mathf.PI); // Generate a random time offset for the wave motion
}

// Update is called once per frame
void Update()
{
    Vector3 direction = (target.position - transform.position).normalized; // Calculate the direction to the target position
    float waveMotion = Mathf.Sin(Time.time * waveFrequency + timeOffset) * waveMagnitude; // Calculate wave motion
    Vector3 movement = direction + (Vector3)perpedicular * waveMotion; // Combine direction with wave motion
    transform.Translate(movement * speed * Time.deltaTime); // Move the mosquito towards the target position
}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
