using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemDatabase : MonoBehaviour
{
    public static WorldItemDatabase Instance;

    [SerializeField] public List<Item> items = new List<Item>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for(int i  = 0; i < items.Count; i++)
        {
            items[i].itemID = i;
        }
    }
}
