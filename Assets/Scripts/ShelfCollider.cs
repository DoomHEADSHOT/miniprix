using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfCollider : MonoBehaviour
{
    [SerializeField] public Collider shelfCollider;
    [SerializeField] public Interactor playerInteractor;
    [SerializeField] ShelfManager targetShelf;

    private void Awake()
    {
        shelfCollider = GetComponent<Collider>();
        playerInteractor = GetComponentInParent<Interactor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        playerInteractor.canInteract = true;
        targetShelf = other.GetComponentInParent<ShelfManager>();

        if(targetShelf != null)
        {
            playerInteractor.shelfManager = targetShelf;
        }
        else
        {
            playerInteractor.shelfManager = null;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInteractor.canInteract = false;
    }
}
