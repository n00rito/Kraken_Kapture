using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControllerPlayer : MonoBehaviour
{
   
    private AudioClip audioClip;
    public AudioSource audioSource;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip;

        // Check if there's an active AudioListener in the current scene
        if (FindObjectOfType<AudioListener>() == null)
        {
            Debug.LogWarning("No active AudioListener found in the scene. Adding one to the main camera.");
            Camera.main.gameObject.AddComponent<AudioListener>();
        }
    }

    void Update()
    {
        if (IsPlayerOnScreen() && !audioSource.isPlaying)
            audioSource.Play();
        else if (!IsPlayerOnScreen() && audioSource.isPlaying)
            audioSource.Stop();
    }

    bool IsPlayerOnScreen()
    {
        Vector3 playerViewportPosition = Camera.main.WorldToViewportPoint(player.transform.position);
        return playerViewportPosition.x > 0 && playerViewportPosition.x < 1 && playerViewportPosition.y > 0 && playerViewportPosition.y < 1 && playerViewportPosition.z > 0;
    }
}