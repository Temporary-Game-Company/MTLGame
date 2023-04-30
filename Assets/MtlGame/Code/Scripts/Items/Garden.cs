using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;

public class Garden : MonoBehaviour
{
    [SerializeField] private ItemSet _items;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Inventory _comboInventory;

    // [SerializeField] private MMFeedback ;

    private InventoryItem _currentItem
    {
        get
        {
            return _inventory.Content[0];
        }
    }

    private InventoryItem _secondItem
    {
        get
        {
            return _inventory.Content[1];
        }
    }

    public void GetItem()
    {
        if (_currentItem != null)
        {
            _inventory.DropItem(_currentItem, 0);
        }

        _inventory.AddItem(_items.GetRandomItem(), 1);
    }

    public void GetSecondItem()
    {
        if (_secondItem != null)
        {
            _inventory.DropItem(_secondItem, 1);
        }

        _inventory.AddItem(_items.GetRandomItem(), 1);
    }
}
