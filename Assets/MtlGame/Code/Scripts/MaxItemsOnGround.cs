using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxItemsOnGround : MonoBehaviour
{
    public GameObject itemPrefab;
    public int maxItems = 5;

    private List<GameObject> items = new List<GameObject>();


    
    public void SpawnItem()
    {
        if (items.Count >= maxItems)
        {
            GameObject oldestItem = items[0];
            items.RemoveAt(0);
            Destroy(oldestItem);
        }

        GameObject newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
        items.Add(newItem);
    }

    // just for debug
    void Update() {

       if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnItem();
        }
        
    }
}
