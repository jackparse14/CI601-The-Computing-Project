using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortFunctions : MonoBehaviour
{
    private ItemType sortType;
    private List<Item> activeItems;
    [SerializeField] private Text searchEntry;
    [SerializeField] private Dropdown dropdownList;

    private ItemType currentSortType;
    private string currentSearchEntry;
    private bool isSortTypeAll = true;
    private bool isSortTypeSearch = false;
    private System.StringComparison stringComparer = System.StringComparison.OrdinalIgnoreCase;
    Dictionary<int, bool> highlightSlotIndex = new Dictionary<int, bool>();
    private void Start()
    {
        SetActiveInventoryItems();
        Inventory.instance.onItemChangedCallback += UpdateSort;
    }
    private void SetActiveInventoryItems() {
        activeItems = Inventory.instance.activeItems;
    }
    private void UpdateSort()
    {
        SetActiveInventoryItems();
        if (isSortTypeAll)
        {
            if (isSortTypeSearch)
            {
                SortBySearch(currentSearchEntry);
            }
            else
            {
                SortByAll();
            }
        }
        else
        {
            SortUI(currentSortType);
        }
    }
    public void HandleDropdownInput(int val) {
        if (val == 0)
        {
            SortByAll();
        }
        else
        {
            switch (val)
            {
                case 0:
                    SortByAll();
                    break;
                case 1:
                    sortType = ItemType.Armour;
                    break;
                case 2:
                    sortType = ItemType.Weapons;
                    break;
                case 3:
                    sortType = ItemType.Utility;
                    break;
                case 4:
                    sortType = ItemType.Crafting;
                    break;
                case 5:
                    sortType = ItemType.KeyItem;
                    break;
                case 6:
                    sortType = ItemType.Junk;
                    break;
            }
            SortUI(sortType);
        }
    }
    public void HandleSearchInput()
    {
        dropdownList.value = 0;
        SortBySearch(searchEntry.text);
    }
    public void SortByAll()
    {
        ClearHighlightDictionary();
        isSortTypeAll = true;
        isSortTypeSearch = false;
        for (int i = 0; i < activeItems.Count; i++)
        {
            AddUnhighlightSlot(i);
        }
        SendHighlightDictionary();
    }
    public void SortUI(ItemType sortType)
    {
        ClearHighlightDictionary();
        currentSortType = sortType;
        isSortTypeAll = false;
        isSortTypeSearch = false;
        for (int i = 0; i < activeItems.Count; i++)
        {
            if (activeItems[i].itemType == sortType)
            {
                AddHighlightSlot(i);
            }
            else
            {
                AddUnhighlightSlot(i);
            }
        }
        SendHighlightDictionary();
    }
    public void SortBySearch(string searchEntry)
    {
        ClearHighlightDictionary();
        isSortTypeSearch = true;
        currentSearchEntry = searchEntry;
        for (int i = 0; i < activeItems.Count; i++)
        {
            if (activeItems[i].itemName.IndexOf(searchEntry, stringComparer) >= 0)
            {
                AddHighlightSlot(i);
            }
            else
            {
                AddUnhighlightSlot(i);
            }
        }
        SendHighlightDictionary();
    }

    private void AddHighlightSlot(int i) {
        highlightSlotIndex.Add(i, true);
    }
    private void AddUnhighlightSlot(int i)
    {
        highlightSlotIndex.Add(i, false);
    }

    private void ClearHighlightDictionary() {
        highlightSlotIndex.Clear();
    }
    private void SendHighlightDictionary()
    {
        UIEvents.uIEvents.Sort(highlightSlotIndex);
    }
}
