using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    PlayerControl playerControl;
    
    public ShelfManager shelfManager;
    public bool isAddingItem = false;
    public bool isRemovingItem = false;
    public bool canInteract = false;
    // Start is called before the first frame update
    public Transform InteractorSource;
    public float InteractRange;
    [SerializeField] Item item;
    void Start()
    {
        item.ItemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (isAddingItem ) 
        {
            isAddingItem = false;
            if (canInteract)
            {
                shelfManager.AddItem(item);
            }
                
        }

        if (isRemovingItem)
        {
            isRemovingItem = false;
            if (canInteract)
            {
                shelfManager.RemoveItem(item);
            }
            
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
