using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using UnityEngine.Events;


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //-----item buttons----//
    [SerializeField] private Button itemButton = null;
    [SerializeField] private Button removeButton = null;

    //------Item data-------//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private int maxNumberOfItems;

    //-----item slot-----//
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;

    //----item desc slot---//

    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //---Check to see if the slot is already full
        if (isFull)
            return quantity;

        //Update name
        this.itemName = itemName;



        //update image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        this.itemDescription = itemDescription;


        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true;
            isFull = true;
        

        int extraItems = this.quantity = maxNumberOfItems;
        this.quantity = maxNumberOfItems;
        return extraItems;


    }
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;
        return 0;

        }

    public virtual void UpdateSlotUI(Item i, int count, UnityAction buttonAction)
    {
        itemName = i.itemName;
        quantity += quantity;

        itemImage.sprite = itemSprite;

        if (buttonAction != null)
        {
            itemButton.onClick.RemoveAllListeners();
            itemButton.onClick.AddListener(buttonAction);
        }
    }



public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button== PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }



    public void OnLeftClick()
    {
        if (thisItemSelected)
        { 
        bool usable = inventoryManager.UseItem(itemName);
        if (usable)
            {
                this.quantity -= 1;
                quantityText.text = this.quantity.ToString();
                if (this.quantity <= 0)
                    EmptySlot();
            }
      


    }
        else { 
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;
        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = itemSprite;
        if(itemDescriptionImage.sprite != null)
        
            itemDescriptionImage.sprite = emptySprite;
        }

    }

    private void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        ItemDescriptionNameText.text = "";
        ItemDescriptionText.text = "";
        itemDescriptionImage.sprite = emptySprite;


    }

    public void OnRightClick()
    {
        
    }

    internal void UpdateSlotUI(ItemSO itemOfType, int count, UnityAction buttonAction)
    {
    }
}
