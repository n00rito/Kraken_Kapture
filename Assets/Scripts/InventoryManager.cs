using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the inventory panel UI
    private bool isInventoryOpen = false; // Flag to track if the inventory is open

    void Update()
    {
        // Check for input to toggle inventory visibility
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryVisibility();
        }
    }

    void ToggleInventoryVisibility()
    {
        // Toggle the visibility of the inventory panel
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.SetActive(true);
    }
}