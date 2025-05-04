using UnityEngine;
using UnityEngine.UI; // Import the Unity UI namespace to use UI elements like Text


public class TheTimer : MonoBehaviour
{
    public Text timeText; // assign via inspector
    public float timePerHour = 60f; // waktu per jam dalam detik
    private int currentHour = 12;
    private float timer = 0f;

    void Start()
    {
        UpdateTimeText();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timePerHour && currentHour < 6)
        {
            timer = 0f;
            currentHour++;

            if (currentHour > 12)
                currentHour = 1;

            UpdateTimeText();
        }
    }

    void UpdateTimeText()
    {
        string suffix = (currentHour >= 12 && currentHour < 24) ? "AM" : "PM";
        timeText.text = currentHour + " " + suffix;
    }
}