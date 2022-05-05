using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item itemType;
    bool pickedUp = false;
    public void PickUp()
    {
        pickedUp = Inventory.instance.Add(itemType);
        if (pickedUp)
        {   
            Destroy(gameObject);
        };
    }
}
