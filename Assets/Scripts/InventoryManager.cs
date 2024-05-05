using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private Dictionary<ItemSO, int> inventory = new Dictionary<ItemSO, int>();

    public GameObject inventoryMenu; // Reference to the inventory panel UI
    private bool menuActivated; // Flag to track if the inventory is open
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    public delegate void OnInventoryChange();
    public OnInventoryChange onInventoryChange;

    public bool HasNumberOfItem(ItemSO item, int numNeeded) => inventory.ContainsKey(item) && inventory[item] >= numNeeded;

    public int NumberHeldOf(ItemSO i) => inventory.ContainsKey(i) ? inventory[i] : 0;

    void Start()
    {
        inventoryMenu.SetActive(false);
        menuActivated = false;
    }


    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.I)) && menuActivated)
        {
            Time.timeScale = 1;
            Debug.Log("inventory activated");
            inventoryMenu.SetActive(false);
            menuActivated = false;
        }

        else if ((Input.GetKeyDown(KeyCode.I)) && !menuActivated)
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    public bool UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                bool usable = itemSOs[i].UseItem();
                return usable;
            }

        }
        return false;
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].name == name || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);


                return leftOverItems;
            }
        }
        return quantity;
    }

    public void AddToInventory(ItemSO item, int count = 1)
    {
        if (!inventory.ContainsKey(item))
            inventory.Add(item, count);

        else
            inventory[item] += count;

        onInventoryChange?.Invoke();
 
}

    public void RemoveFromInventory(ItemSO item, int count)
    {
        if (!inventory.ContainsKey(item))
            throw new System.Exception("The dictionary doesn't contain that item. How did we get here?");

        if (inventory[item] >= count)
            inventory[item] -= count;
        else
        {
            Debug.LogWarning($"Inventory contains less that {count} of {item.name}. Setting count to zero");
            inventory[item] = 0;
        }

        onInventoryChange?.Invoke();
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

    