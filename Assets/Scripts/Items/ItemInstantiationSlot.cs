using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstantiationSlot : MonoBehaviour
{
    public int itemID;
    public GameObject currentItemModel = null;

    public void UnloadItem()
    {
        if (currentItemModel != null)
        {
            Debug.Log("Unloading item with ID " + itemID);
            Destroy(currentItemModel);
            currentItemModel = null; // Set to null to avoid referencing a destroyed object
            itemID = 999; // Reset item ID to indicate the slot is empty
        }
        else
        {
            Debug.LogError("Cannot unload item because currentItemModel is null");
        }
    }

    public void LoadItem(GameObject ItemModel)
    {
        currentItemModel = ItemModel;
        ItemModel.transform.parent = transform;

        ItemModel.transform.localPosition = Vector3.zero;
        ItemModel.transform.localRotation = Quaternion.identity;
        ItemModel.transform.localScale = Vector3.one;
    }
}
