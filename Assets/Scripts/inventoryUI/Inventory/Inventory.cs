using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventoryCanvas;
    public List<Item> redItems = new List<Item>();
    public List<Item> blueItems = new List<Item>();
    public List<Item> greenItems = new List<Item>();
    public List<Item> purpleItems = new List<Item>();
    public List<Item> activeItems;
    [SerializeField] public int inventorySpace = 70;
    #region -Singleton/Awake-
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
        }
        else
        {
            instance = this;
        }
        activeItems = redItems;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public void SetActiveInv(int ID)
    {
        if (ID == 0)
        {
            activeItems = redItems;
        }
        else if (ID == 1)
        {
            activeItems = blueItems;
        }
        else if (ID == 2)
        {
            activeItems = greenItems;
        }
        else if (ID == 3)
        {
            activeItems = purpleItems;
        }
        else
        {
            Debug.Log("ERROR ID INVALID");
        }
        InvokeItemChangedCallback();
    }
    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (activeItems.Count >= inventorySpace)
            {
                string player = null;
                if (activeItems == redItems) {
                    player = "Red";
                } else if (activeItems == blueItems) {
                    player = "Blue";
                } else if (activeItems == greenItems) {
                    player = "Green";
                } else if (activeItems == purpleItems) {
                    player = "Purple";
                } else {
                    Debug.Log("ERROR INVENTORY");
                }
                UIEvents.uIEvents.InventoryIsFull(player);
                return false;
            }
                activeItems.Add(item);
            InvokeItemChangedCallback();
        }
        return true;
    }
    public void AddSpecific(int index,Item item) {
        activeItems.Insert(index, item);
        InvokeItemChangedCallback();
    }
    public void MoveItemFromInventory(List<Item> listToMoveTo, Item item, int indexOfSlot) {
        listToMoveTo.Add(item);
        Remove(indexOfSlot);
    }
    
    public void SwapItems(int itemIndex1, int itemIndex2) { 
        Item temp = activeItems[itemIndex2];
        activeItems[itemIndex2] = activeItems[itemIndex1];
        activeItems[itemIndex1] = temp;
        InvokeItemChangedCallback();
    }
    public void Remove(int index)
    {
        activeItems.RemoveAt(index);
        InvokeItemChangedCallback();
    }
    private void InvokeItemChangedCallback() {
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}