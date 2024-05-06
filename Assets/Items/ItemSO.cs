using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public int price;

    public bool UseItem()
    {

        if (statToChange == StatToChange.health)
        {
            Health playerHealth = GameObject.Find("Player").GetComponent<Health>();
            if (playerHealth.health == playerHealth.maxHealth)
            {
                return false;
            }
            else
            {
                playerHealth.RestoreHealth(amountToChangeStat);
                return true;

            }
        }
        return false;

    }

    public enum StatToChange
    {
        none,
        health
    };

 
}
