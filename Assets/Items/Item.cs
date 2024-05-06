using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;

    [SerializeField] private int quantity;

    [SerializeField] private Sprite sprite;


    [SerializeField] private int value = 1;

    [TextArea]
    [SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if(leftOverItems <= 0)
            Destroy(gameObject);
            else
                quantity = leftOverItems;
        }


    }

    public int GetPrice()
    {
        return value;
    }
}
