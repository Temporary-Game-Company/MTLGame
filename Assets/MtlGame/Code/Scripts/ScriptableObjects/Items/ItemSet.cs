using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

[CreateAssetMenu(menuName = "Items/ItemSet")]
public class ItemSet : ScriptableObject
{
    [SerializeField] private List<InventoryItem> _items;

    public List<InventoryItem> GetItems()
    {
        return _items;
    }

    public InventoryItem GetRandomItem()
    {        
        int randomIndex = Random.Range(0, _items.Count);
        return _items[randomIndex];
    }
}
