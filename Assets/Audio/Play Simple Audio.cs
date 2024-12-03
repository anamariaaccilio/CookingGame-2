using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySimpleAudio : MonoBehaviour
{
    public AudioClip audioClip;  // Reference to the audio clip you want to play
    private AudioSource audioSource;  // AudioSource component to play the audio

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();

        // Set the clip to the audio clip provided in the inspector
        audioSource.clip = audioClip;

        // Set loop to true so the audio will repeat continuously
        audioSource.loop = true;

        // Start playing the audio clip
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // No need to check anything here, since the audio will keep looping.
    }
}
