using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    SceneLoader loader;
    public float newTime = 10f;
    public float timeRemaining = 10f; // Timer duration in seconds
    public bool timerIsRunning = false; // Flag to turn timer on/off
    public TextMeshProUGUI timerText; // UI Text to display timer
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Debug.Log("Timer has ended!");
                SceneManager.LoadScene(0);
                Destroy(gameObject);

            }
        }
        if (!timerIsRunning)
        {
            ResetTimer();
            StartTimer();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void StartTimer()
    {
        timerIsRunning = true;
    }
    public void StopTimer()
    {
        timerIsRunning = false;
    }
    public void ResetTimer()
    {
        timeRemaining = 10f;
        timerIsRunning = false;
        DisplayTime(timeRemaining);
    }
}

