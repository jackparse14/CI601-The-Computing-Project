using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public Transform inventorySlotsParent;
    public Transform equippedSlotsParent;
    private List<Item> activeItems;
    private EquipItem[] equippedActiveItems;
    public EquippedSlot[] equippedSlots;
    public InventorySlot[] inventorySlots;
    public ItemOptions itemOptionsPrefab;
    public ItemOptions currentItemOptions;
    public MoveDropdown currentMoveDropdown;

    public SlotDraggable slotDraggablePrefab;
    private SlotDraggable currentSlotDraggable;
    public InventorySlot currentInventorySlot;
    private EquippedSlot currentEquippedSlot;
    public DeleteUI deleteUI;

    private AudioManager audioManager;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        SetActiveInventoryItems();
        InitializeEventListeners();
        inventorySlots = inventorySlotsParent.GetComponentsInChildren<InventorySlot>();
        equippedSlots = equippedSlotsParent.GetComponentsInChildren<EquippedSlot>();
        gameObject.SetActive(false);
    }
    private void InitializeEventListeners()
    {
        EquippedInventory.instance.onEquippedItemChangedCallback += UpdateEquippedInventoryUI;
        Inventory.instance.onItemChangedCallback += UpdateInventoryUI;

        UIEvents.uIEvents.onSort += HighlightSlots;

        UIEvents.uIEvents.onInventorySlotDragEnd += HandleEndDrag;
        UIEvents.uIEvents.onInventorySlotDragStart += HandleBeginDrag;
        UIEvents.uIEvents.onInventorySlotDroppedOn += HandleSwap;
        UIEvents.uIEvents.onInventorySlotOnDrag += HandleDrag;
        UIEvents.uIEvents.onInventorySlotRemoveClicked += HandleDisplayDeleteItem;

        UIEvents.uIEvents.onEquippedSlotDroppedOn += HandleEquipGear;
        UIEvents.uIEvents.onEquippedSlotDragStart += HandleEquippedDragStart;
        UIEvents.uIEvents.onEquippedSlotDragEnd += HandleEquippedDragEnd;
        
        UIEvents.uIEvents.onNavigationDroppedOn += HandleMoveInventory;
    }
    private void HandleDisplayDeleteItem(InventorySlot slot){
        deleteUI.OnDisplayDeleteItem(inventorySlots,slot);
    }

    private void HandleEquippedDragEnd(EquippedSlot slot)
    {
        currentEquippedSlot.icon.color = Color.white;
        DestroyInventorySlotDraggable();
        currentEquippedSlot.iconCanvas.sortingOrder = 1;
        currentEquippedSlot = null;
    }

    private void HandleEquippedDragStart(EquippedSlot slot)
    {
        currentEquippedSlot = slot;
        currentEquippedSlot.icon.color = Color.red;
        InstantiateEquippedSlotDraggable(currentEquippedSlot);
        currentSlotDraggable.SetIcon(currentEquippedSlot.icon);
        currentEquippedSlot.iconCanvas.sortingOrder = 10;
    }

    private void HandleEquipGear(EquippedSlot slot)
    {
        if (currentInventorySlot != null)
        {
            if (currentInventorySlot.item is EquipItem equipItem)
            {

                if (slot.slotType.ToString() == equipItem.armourType.ToString())
                {
                    if (slot.item == null)
                    {
                        EquippedInventory.instance.Add(equipItem, slot.slotIndex);
                        Inventory.instance.Remove(Array.IndexOf(inventorySlots, currentInventorySlot));
                    }
                    else
                    {
                        int slotDraggedIndex = Array.IndexOf(inventorySlots, currentInventorySlot);
                        Item refItem = slot.item;
                        EquippedInventory.instance.Add(equipItem, slot.slotIndex);
                        Inventory.instance.Remove(slotDraggedIndex);
                        Inventory.instance.AddSpecific(slotDraggedIndex, refItem);
                    }
                    audioManager.PlaySound("EquipGear");
                }
                DestroyInventorySlotDraggable();
                currentInventorySlot.icon.color = Color.white;
                currentInventorySlot = null;
            }

        }
    }


    private void HandleMoveInventory(List<Item> listToMoveTo) {
        if (listToMoveTo.Count < Inventory.instance.inventorySpace) {
            if (currentInventorySlot != null)
            {
                Inventory.instance.MoveItemFromInventory(listToMoveTo, currentInventorySlot.item, Array.IndexOf(inventorySlots, currentInventorySlot));
                currentInventorySlot.icon.color = Color.white;
                DestroyInventorySlotDraggable();
                currentInventorySlot.iconCanvas.sortingOrder = 1;
            }
            else if (currentEquippedSlot != null)
            {
                EquippedInventory.instance.MoveItemFromEquipped(listToMoveTo, currentEquippedSlot);
                currentEquippedSlot.icon.color = Color.white;
                DestroyInventorySlotDraggable();
                currentEquippedSlot.iconCanvas.sortingOrder = 1;
            }
        }
    }
    private void HandleSwap(InventorySlot slot)
    {
        
        if (currentInventorySlot != null)
        {
            int slotDraggedIndex = Array.IndexOf(inventorySlots, currentInventorySlot);
            if (slot.item != null)
            {
                int slotDroppedOnIndex = Array.IndexOf(inventorySlots, slot);
                Inventory.instance.SwapItems(slotDraggedIndex, slotDroppedOnIndex);
                audioManager.PlaySound("EquipGear");
            }
            else
            {
                if (currentInventorySlot.item != null)
                {
                    Item addItem = currentInventorySlot.item;
                    Inventory.instance.Remove(Array.IndexOf(inventorySlots, currentInventorySlot));
                    Inventory.instance.Add(addItem);
                    currentInventorySlot.icon.color = Color.white;
                    currentInventorySlot = null;
                    DestroyInventorySlotDraggable();
                    audioManager.PlaySound("EquipGear");
                }
            }
        }
        else if (currentEquippedSlot != null) {
            
            if (slot.item != null)
            {
                if (slot.item is EquipItem equipItem && currentEquippedSlot.item is EquipItem equipItem2) {
                    if (equipItem.armourType.ToString() == equipItem2.armourType.ToString())
                    {
                        int slotDraggedIndex = Array.IndexOf(inventorySlots, slot);
                        Item refItem = currentEquippedSlot.item;
                        EquippedInventory.instance.Add(equipItem, currentEquippedSlot.slotIndex);
                        Inventory.instance.Remove(slotDraggedIndex);
                        Inventory.instance.AddSpecific(slotDraggedIndex, refItem);
                        audioManager.PlaySound("EquipGear");
                    }
                }
                
            }
            else
            {
                if (currentEquippedSlot.item != null)
                {
                    Inventory.instance.Add(currentEquippedSlot.item);
                    EquippedInventory.instance.Remove(currentEquippedSlot.slotIndex);
                    DestroyInventorySlotDraggable();
                    currentEquippedSlot.icon.color = Color.white;
                    currentEquippedSlot = null;
                    audioManager.PlaySound("EquipGear");
                }
            }

        }
        
    }
    private void HandleDrag(Vector2 currMousePosition)
    {
            float newX = currMousePosition.x - 10;
            float newY = currMousePosition.y + 10;
            Vector2 newMousePosition = new Vector2(newX, newY);
            currentSlotDraggable.transform.position = newMousePosition;
    }

    private void HandleBeginDrag(InventorySlot slot)
    {
        currentInventorySlot = slot;
        currentInventorySlot.icon.color = Color.red;
        InstantiateInventorySlotDraggable(currentInventorySlot);
        currentSlotDraggable.SetIcon(currentInventorySlot.icon);
        currentInventorySlot.iconCanvas.sortingOrder = 10;
    }

    private void HandleEndDrag(InventorySlot slot)
    {
        if (currentInventorySlot != null) {
            currentInventorySlot.icon.color = Color.white;
            DestroyInventorySlotDraggable();
            currentInventorySlot.iconCanvas.sortingOrder = 1;
            currentInventorySlot = null;
        }
    }
    private void InstantiateInventorySlotDraggable(InventorySlot inventorySlot) {
        currentSlotDraggable = Instantiate(slotDraggablePrefab, inventorySlot.iconCanvas.transform);
    }
    private void InstantiateEquippedSlotDraggable(EquippedSlot inventorySlot)
    {
        currentSlotDraggable = Instantiate(slotDraggablePrefab, inventorySlot.iconCanvas.transform);
    }
    private void DestroyInventorySlotDraggable() {
        if (currentSlotDraggable != null) {
            currentSlotDraggable.DestroySelf();
        }
        
    }
    private void SetActiveInventoryItems() {
        activeItems = Inventory.instance.activeItems;
        equippedActiveItems = EquippedInventory.instance.equippedActiveItems;
    }

    public void UpdateInventoryUI()
    {
        SetActiveInventoryItems();
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (i < activeItems.Count)
            {
                inventorySlots[i].AddItem(activeItems[i]);
            }
            else
            {
                inventorySlots[i].ClearItem();
                inventorySlots[i].UnhighlightSlot();
            }
        }
    }
    private void UpdateEquippedInventoryUI()
    {
        SetActiveInventoryItems();
        for (int i = 0; i < equippedSlots.Length; i++)
        {
            if (equippedActiveItems[i] != null)
            {
                equippedSlots[i].AddItem(equippedActiveItems[i]);
            }
            else {
                equippedSlots[i].ClearItem();
            }
        }
        UIEvents.uIEvents.EquippedInventoryChange();
    }
    public void InstantiateDropdownList(InventorySlot inventorySlot) {
        if (inventorySlot.item != null) {
            currentItemOptions = Instantiate(itemOptionsPrefab, inventorySlot.iconCanvas.transform);
            currentItemOptions.SetInventorySlot(inventorySlot);
            currentInventorySlot = inventorySlot;
            inventorySlot.iconCanvas.sortingOrder = 10;
        }
    }
    public void DestroyDropdownList()
    {
        currentInventorySlot = null;
        currentItemOptions.DestroySelf();

    }
    public void DestroyMoveList()
    {
        currentInventorySlot = null;
        currentMoveDropdown.DestroySelf();
    }
    private void HighlightSlots(Dictionary<int,bool> highlightSlotIndex) {
        foreach(var slot in highlightSlotIndex){
            if (slot.Value)
            {
                inventorySlots[slot.Key].HighlightSlot();
            }
            else {
                inventorySlots[slot.Key].UnhighlightSlot();
            }
        }
    }
    public void OpenCloseInventory()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}