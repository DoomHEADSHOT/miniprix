using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public static ShelfManager instance;
    public List<GameObject> storedItems; // List of stored items
    public int maxItems = 10; // Max items a shelf can hold
    public Transform[] itemPositions; // Positions where items can be placed

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Adds an item to the shelf
    public bool AddItem(GameObject itemPrefab)
    {
        if (storedItems.Count >= maxItems)
        {
            Debug.Log("Shelf is full!");
            return false;
        }

        GameObject newItem = Instantiate(itemPrefab, itemPositions[storedItems.Count].position, Quaternion.identity);
        newItem.transform.SetParent(this.transform); // Make item a child of the shelf
        storedItems.Add(newItem);
        return true;
    }

    // Removes an item from the shelf
    public bool RemoveItem(GameObject item)
    {
        if (storedItems.Contains(item))
        {
            storedItems.Remove(item);
            Destroy(item);
            return true;
        }
        Debug.Log("Item not found on shelf!");
        return false;
    }
}
