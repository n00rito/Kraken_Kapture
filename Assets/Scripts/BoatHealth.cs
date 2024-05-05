using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoatHealth : MonoBehaviour
{
    public int health;
    public int maxhealth = 100;
    public Slider slider;


    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        slider.maxValue = maxhealth;
        slider.value = health;
    }



    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
