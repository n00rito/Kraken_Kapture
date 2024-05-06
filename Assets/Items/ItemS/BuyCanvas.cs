using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCanvas : MonoBehaviour
{
    public Button buyBeer;
    public Button buyBurger;
    public Wallet wallet;
    public InventoryManager inventory;

    public int beerPrice = 70;
    public int burgerPrice = 150;

    // Method to handle selling jellyfish
    public void BuyBeer()
    {

        // Add money to the wallet
        wallet.RemoveMoney(beerPrice);

        // Remove the jellyfish item (implement this method in your Inventory or ItemManager script)
        // For example:
        inventory.UseItem("Beer");
        // inventory.RemoveItem("Jellyfish");

        Debug.Log("Beer bought for " + beerPrice + " money.");
    }

    // Method to handle selling shark meat
    public void BuyBurger()
    {
        // Add money to the wallet
        wallet.RemoveMoney(burgerPrice);

        // Remove the shark meat item (implement this method in your Inventory or ItemManager script)
        // For example:
        inventory.UseItem("Burger");
        // inventory.RemoveItem("Shark Meat");

        Debug.Log("Burger bought for " + burgerPrice + " money.");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Link click handlers to button events
        buyBeer.onClick.AddListener(BuyBeer);
        buyBurger.onClick.AddListener(BuyBurger);
    }
}