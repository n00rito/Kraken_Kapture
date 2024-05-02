using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class ItemDataWeapon : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int itemId;
    public string description;
    public int damage;
    // Add more fields as needed (e.g., item type, stats, etc.)
}