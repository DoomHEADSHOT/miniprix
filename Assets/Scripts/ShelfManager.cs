using System.Collections.Generic;
using System.Linq;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
    public static ShelfManager instance;
    public List<Item> storedItems; // List of stored items
    public int maxItems = 10; // Max items a shelf can hold
    public Transform[] itemPositions; // Positions where items can be placed
    public Vector3 velocity;
    public float itemSmoothSpeed;
    public GameObject lastItem = null;
    public ItemInstantiationSlot[] itemSlots;
    public int itemCount = 0;

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

        itemSlots = GetComponentsInChildren<ItemInstantiationSlot>();
    }

    private void Update()
    {
        /*if (lastItem != null)
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
        }
        else
        {
            storedItems.FirstOrDefault(i => i.itemID == newItem.itemID).ItemCount ++;
        }

        lastItem = Instantiate(item.itemModel);
        foreach(ItemInstantiationSlot slot in itemSlots)
        {
            if(slot.currentItemModel == null)
            {
                slot.LoadItem(lastItem);
                slot.itemID = item.itemID;
                itemCount++;
                return true;
            }
        }

        /*GameObject newItem = Instantiate(itemPrefab,PlayerManager.instance.transform.position , Quaternion.identity);
        newItem.transform.SetParent(this.transform); // Make item a child of the shelf
        storedItems.Add(newItem);
        lastItem = newItem;*/
        return false;
    }

    // Removes an item from the shelf
    public bool RemoveItem(Item item)
    {
        if (storedItems.Contains(item))
        {
            Item removedItem = storedItems.FirstOrDefault(i => i.itemID == item.itemID);
            Debug.Log("Item found : " + removedItem.itemName);
            foreach (ItemInstantiationSlot slot in itemSlots)
            {
                if (slot.itemID == removedItem.itemID)
                {
                    Debug.Log("Item Model found : " + removedItem.itemName);
                    slot.UnloadItem();
                    removedItem.ItemCount--;
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
