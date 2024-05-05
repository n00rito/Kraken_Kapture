using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShopManager : MonoBehaviour
{
    public GameObject shopMenu; // Reference to the inventory panel UI
    private bool shopActivated; // Flag to track if the inventory is open
    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;


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
    }


