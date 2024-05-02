using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]

public class ConsumableData : ScriptableObject
{ 

    public string itemName;
    public Sprite itemIcon;
    public int itemId;
    public string description;
    public int HP;
    // Add more fields as needed (e.g., item type, stats, etc.)
}
