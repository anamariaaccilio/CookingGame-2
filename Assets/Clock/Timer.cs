using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    AudioSource m_AudioClockTick;
    public AudioClip m_AudioClip;  // Reference to the tick sound

    public TextMeshPro m_TimerText;  // Reference to the TextMeshPro component
    public int m_StartMinutes = 4;   // Starting minutes (you can change this value)
    public int m_StartSeconds = 0;   // Starting seconds (you can change this value)

    private float timeRemaining;   // Time remaining in seconds
    private float lastTickTime;    // Tracks the last time the tick sound was played
    private bool isInLastMinute = false; // Flag to track if we're in the last minute

    // Start is called before the first frame update
    void Start()
    {
        // Convert starting minutes and seconds to total seconds
        timeRemaining = m_StartMinutes * 60 + m_StartSeconds;
        UpdateTimerText();

        // Audio Start
        m_AudioClockTick = gameObject.AddComponent<AudioSource>();
        m_AudioClockTick.clip = m_AudioClip;  // Set the tick sound clip
        m_AudioClockTick.loop = false;  // Ensure it doesn't loop (since it's a single tick sound)
        lastTickTime = timeRemaining;  // Set the initial last tick time
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;  // Decrease the time by the time passed since the last frame
        }
        else
        {
            // Ensure timeRemaining doesn't go below zero
            timeRemaining = 0;
        }

        UpdateTimerText();  // Update the text on each frame

        // Check if we're in the last minute of the timer
        if (timeRemaining <= 60 && !isInLastMinute)
        {
            // We're entering the last minute
            isInLastMinute = true;
            lastTickTime = timeRemaining; // Reset last tick time to ensure it plays the tick sound
        }

        // Play tick sound every second during the last minute (ensure it's only played once per second)
        if (isInLastMinute && Mathf.Floor(timeRemaining) < Mathf.Floor(lastTickTime))
        {
            // Play tick sound
            m_AudioClockTick.Play();

            // Update the last tick time
            lastTickTime = timeRemaining;
        }
    }

    // Function to update the timer text
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);  // Get minutes
        int seconds = Mathf.FloorToInt(timeRemaining % 60);  // Get remaining seconds

        // Format the time as "MM:SS" and set it to the TextMeshPro component
        // Ensure the time doesn't go below zero (it will show 00:00 when the timer reaches zero)
        m_TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
