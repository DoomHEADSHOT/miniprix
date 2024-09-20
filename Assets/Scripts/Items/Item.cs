using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Fruit")]
public class Item : ScriptableObject
{
    [Header("Item Information")]
    public string itemName;
    public float itemPrice;
    public int itemID;
    public Sprite itemIcon;
    public int ItemCount = 0;

    [SerializeField] public GameObject itemModel;

    private void Awake()
    {
        ItemCount = 0;
    }

}
