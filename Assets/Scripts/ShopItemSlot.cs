using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopItemSlot : MonoBehaviour
{

    public ShopManager shopManager;
    public ItemSlot slot;

    //-----item data----//
    public int quantity;
    public string itemName;
    public Sprite itemSprite;
    public Sprite emptySprite;
    private TMP_Text quantityText;
    public TMP_Text price;


    public void OnLeftClick()
    {
        if (slot.thisItemSelected)
        {
            // Attempt to buy the item from the shop
            bool bought = shopManager.BuyItem(itemName);

            if (bought)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();

            }
            else
            {
                // Handle case where item cannot be bought
                Debug.Log("Failed to buy item: " + itemName);
            }
        }


    }
}


