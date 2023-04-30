using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryItem _item;
    [SerializeField] private Inventory _inventory;

    // [SerializeField] private MMFeedback ;

    private InventoryItem _currentItem
    {
        get
        {
            return _inventory.Content[0];
        }
    }

    public void GetItem()
    {
        if (_currentItem != null)
        {
            _inventory.DropItem(_currentItem, 0);
        }

        _inventory.AddItem(_item, 1);
    }
}
