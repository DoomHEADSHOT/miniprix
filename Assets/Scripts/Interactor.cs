using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    PlayerControl playerControl;
    
    public bool isAddingItem = false;
    public bool isRemovingItem = false;
    // Start is called before the first frame update
    public Transform InteractorSource;
    public float InteractRange;
    [SerializeField] Item item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isAddingItem) {
            isAddingItem = false;
            ShelfManager.instance.AddItem(item);
            Debug.Log("E pressed");
        }

        if (isRemovingItem)
        {
            isRemovingItem = false;
            ShelfManager.instance.RemoveItem(item);
            Debug.Log("A pressed");
        }

    }
    private void OnEnable()
    {
        playerControl = new PlayerControl();

        playerControl.Interact.AddItem.performed += i => isAddingItem = true;
        playerControl.Interact.RemoveItem.performed += i => isRemovingItem = true;

        playerControl.Enable();
    }
}
