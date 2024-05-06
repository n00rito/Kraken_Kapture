using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellCanvas : MonoBehaviour
{
    public Button sellJellyfish;
    public Button sellSharkmeat;
    public Wallet wallet;
    public InventoryManager inventory;

    public int jellyfishPrice = 100;
    public int sharkmeatPrice = 60;

    // Method to handle selling jellyfish
    public void SellJellyfish()
    {

        // Add money to the wallet
        wallet.AddMoney(jellyfishPrice);

        // Remove the jellyfish item (implement this method in your Inventory or ItemManager script)
        // For example:
        inventory.UseItem("Dead Jellyfish");
        // inventory.RemoveItem("Jellyfish");

        Debug.Log("Jellyfish sold for " + jellyfishPrice + " money.");
    }

    // Method to handle selling shark meat
    public void SellSharkmeat()
    {
        // Add money to the wallet
        wallet.AddMoney(sharkmeatPrice);

        // Remove the shark meat item (implement this method in your Inventory or ItemManager script)
        // For example:
        // inventory.RemoveItem("Shark Meat");

        Debug.Log("Shark meat sold for " + sharkmeatPrice + " money.");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Link click handlers to button events
        sellJellyfish.onClick.AddListener(SellJellyfish);
        sellSharkmeat.onClick.AddListener(SellSharkmeat);
    }
}