using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class ShopManager : MonoBehaviour
{
    public GameObject shopMenu; // Reference to the inventory panel UI
    private bool shopActivated; // Flag to track if the inventory is open
    public ShopItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    public Collider2D shopZone;

    public Wallet wallet;

    public ItemSO itemSO;


    void Start()
    {
        shopMenu.SetActive(false);
        shopActivated = false;

    }

    void Update()
    {
        // Check if the shop menu is activated and the player presses the appropriate key to close it
        if (shopActivated && Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            Debug.Log("shop activated");
            shopMenu.SetActive(false);
            shopActivated = false;
        }

        else if ((Input.GetKeyDown(KeyCode.P)) && !shopActivated)
        {
            Time.timeScale = 0;
            shopMenu.SetActive(true);
            shopActivated = true;
        }

    }

    public bool BuyItem(string itemName)
    {
        if (itemSO != null)
        {
            int itemValue = itemSO.price;

            // Check if the player has enough money to buy the item
            if (wallet.GetMoney() >= itemSO.price)
            {
                // Remove money from the wallet equal to the item price
                wallet.RemoveMoney(itemSO.price);
                Debug.Log("Bought item: " + itemName);
                return true; // Item successfully bought
            }
            else
            {
                Debug.Log("Not enough money to buy item: " + itemName);
                return false; // Not enough money to buy the item
            }
        }
        else
        {
            Debug.Log("ItemSO is null. Cannot buy item.");
            return false; // ItemSO is null, cannot buy item
        }
    }
}





