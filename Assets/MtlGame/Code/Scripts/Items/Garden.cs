using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class Garden : MonoBehaviour
{
    [SerializeField] private ItemSet _items;
    [SerializeField] private Inventory _inventory;

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

        _inventory.AddItem(_items.GetRandomItem(), 1);
    }
}
