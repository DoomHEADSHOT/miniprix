using System.Collections.Generic;
using System.Linq;
 
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public static ShelfManager instance;
    public List<Item> storedItems; // List of stored items
    public int maxItems = 10; // Max items a shelf can hold
    public Transform[] itemPositions; // Positions where items can be placed
    public Vector3 velocity;
    public float itemSmoothSpeed;
    public GameObject itemModel = null;
    public ItemInstantiationSlot[] itemSlots;
    public int itemCount = 0;

    private void Awake()
    {
        instance = this;
        itemSlots = GetComponentsInChildren<ItemInstantiationSlot>();
    }

    private void Update()
    {
        /*if (itemModel != null)
        {
            for (int i = 0; i < storedItems.Count; i++)
            {
                storedItems[i].transform.position = Vector3.SmoothDamp(storedItems[i].transform.position, itemPositions[i].position, ref velocity, itemSmoothSpeed);
            }
        }*/

    }
    // Adds an item to the shelf
    public bool AddItem(Item item)
    {
        Item newItem = item;
        if (itemCount >= itemSlots.Length)
        {
            Debug.Log("Shelf is full!");
            return false;
        }

        if(!storedItems.Contains(item))
        {
            newItem.ItemCount++;
            storedItems.Add(newItem);
            Debug.Log("1- Stored items count: " + storedItems[0].ItemCount);
        }
        else
        {
            storedItems.FirstOrDefault(i => i.itemID == newItem.itemID).ItemCount ++;
            Debug.Log("2- Stored items count: " + storedItems[0].ItemCount);
        }

        itemModel = Instantiate(item.itemModel);
        foreach(ItemInstantiationSlot slot in itemSlots)
        {
            if(slot.currentItemModel == null)
            {
                slot.LoadItem(itemModel);
                slot.itemID = item.itemID;
                itemCount++;
                return true;
            }
        }
        return false;
    }

    // Removes an item from the shelf
    public bool RemoveItem(Item item)
    {
        if (storedItems.Contains(item))
        {
            Item removedItem = storedItems.FirstOrDefault(i => i.itemID == item.itemID);
            Debug.Log("Item found : " + removedItem.itemName);
            foreach (ItemInstantiationSlot slot in itemSlots.Reverse())
            {
                if (slot.itemID == removedItem.itemID && slot.currentItemModel != null)
                {
                    Debug.Log("Item Model found : " + removedItem.itemName);    
                    slot.UnloadItem();
                    storedItems.FirstOrDefault(i => i.itemID == removedItem.itemID).ItemCount--;
                    itemCount--;
                    Debug.Log("3- Stored items count :" + storedItems[0].ItemCount);
                    Debug.Log("Item count = " + removedItem.ItemCount);
                    if(removedItem.ItemCount <= 0)
                    {
                        removedItem.ItemCount = 0;
                        Debug.Log("Item done");
                        storedItems.Remove(removedItem);
                    }
                    return true;
                }
            }
          
        }
        Debug.Log("Item not found on shelf!");
        return false;
    }
}
