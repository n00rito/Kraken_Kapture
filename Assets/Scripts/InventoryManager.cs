using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public GameObject inventoryMenu; // Reference to the inventory panel UI
    private bool menuActivated; // Flag to track if the inventory is open
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

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

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}

    