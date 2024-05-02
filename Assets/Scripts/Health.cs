using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public int health;
    public int maxhealth = 75;
    public Slider slider;
    

    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        slider.maxValue = maxhealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

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
