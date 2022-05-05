using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteUI : MonoBehaviour
{
    [SerializeField] private Text nametext;
    [SerializeField] private Image image;
    Inventory inventory;
    private Item possibleDeleteItem;
    private AudioManager audioManager;
    private InventorySlot[] slots;
    private InventorySlot currSlot;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        CloseTab();
        inventory = Inventory.instance;
    }

    public void OnYesClick()
    {
        audioManager.PlaySound("Remove");
        inventory.Remove(Array.IndexOf(slots,currSlot));
        UIEvents.uIEvents.InventorySlotEmptyClicked();
        CloseTab();
    }
    public void OnNoClick()
    {
        audioManager.PlaySound("UIClick");
        CloseTab();
    }
    public void OnDisplayDeleteItem(InventorySlot[] slotsArray,InventorySlot slot)
    {
        slots = slotsArray;
        currSlot = slot;
        audioManager.PlaySound("Remove");
        possibleDeleteItem = currSlot.item;
        nametext.text = possibleDeleteItem.itemName;
        image.sprite = possibleDeleteItem.icon;
        OpenTab();
    }
    public void CloseTab()
    {
        gameObject.SetActive(false);
    }
    private void OpenTab()
    {
        gameObject.SetActive(true);
    }
}