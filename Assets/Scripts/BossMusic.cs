using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip bossMusic, defaultMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        defaultMusic = audioSource.clip;
        audioSource.clip = defaultMusic;
        audioSource.Play();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = bossMusic;
            audioSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audioSource.clip = defaultMusic;
            audioSource.Play();
        }
    }

}