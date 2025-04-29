using UnityEngine;
using System.Collections.Generic; // Import the Collections.Generic namespace
using System.Collections; // Import the Collections namespace

public class Mosquito : MonoBehaviour
{
    public float speed = 5f; 
    public float waveFrequency = 1f; // Frequency of the wave motion
    public float waveMagnitude = 0.5f; // Magnitude of the wave motion
    public GameObject clickParticle;


    private Transform target; // Target transform for the mosquito to move towards
    private Vector2 moveDirection; // Direction of movement for the mosquito
    private Vector2 perpedicular; 
    private float timeOffset;
    private bool isClicked = false; // Flag to check if the mosquito is clicked
    


    void Start()
    {
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
        transform.Translate(direction * speed * Time.deltaTime); // Move the mosquito towards the target position

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Calculate the angle to rotate towards the target position
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Rotate the mosquito to face the target position
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Cat")) // Check if the mosquito collides with the cat
        {
            collision.GetComponent<CatAttributes>().TakeDamage(1); // Call the TakeDamage method on the cat's attributes script
            Destroy(gameObject); // Destroy the mosquito
            Debug.Log("Mosquito hit the cat!"); // Log a message to the console
        }
    }

    void OnMouseDown()
    {
        isClicked = true; // Set the clicked flag to true when the mosquito is clicked
        Destroy(gameObject); // Destroy the mosquito
        Debug.Log("Mosquito licked!"); // Log a message to the console
    }

}

