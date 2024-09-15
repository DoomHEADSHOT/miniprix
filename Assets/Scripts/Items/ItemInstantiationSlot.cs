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
            itemID = 999;
            Destroy(currentItemModel);
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
