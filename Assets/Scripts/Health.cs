using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 75;
    public Slider slider;
    public TextMeshProUGUI healthText;
    Vector2 startPos;
    public AudioClip ouchSound;

    private AudioSource audioSource;
    // public AudioClip ouchClip;
    // private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        UpdateHealthText();
        //audioSource = GetComponent<AudioSource>();
        // audioSource.clip = ouchClip;
    }

            public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;
        UpdateHealthText();

        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(1);
        }
    }

    public void PlaySoundEffect()
    {
        audioSource.Play();
    }


public void RestoreHealth(int amount)
    { 
        health += amount;
        slider.value = health;
        UpdateHealthText();
    }

        // Method to update the health text
        void UpdateHealthText()
    {
        healthText.text = "Health: " + health.ToString(); // Display the current health as text
    }
}
