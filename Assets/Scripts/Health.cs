using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 75;
    public Slider slider;
    public TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
        UpdateHealthText(); // Update the health text initially
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;
        UpdateHealthText(); // Update the health text after taking damage

        if (health <= 0)
        {
            Destroy(gameObject);
        }
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
