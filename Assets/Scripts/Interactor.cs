using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    PlayerControl playerControl;
    
    bool interactionTrue;
    // Start is called before the first frame update
    public Transform InteractorSource;
    public float InteractRange;
    [SerializeField] GameObject item;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (interactionTrue) {
            interactionTrue = false;
            ShelfManager.instance.AddItem(item);
            Debug.Log("E pressed");
        }
    }
    private void OnEnable()
    {
        playerControl = new PlayerControl();

        playerControl.Interact.Interaction.performed += i => interactionTrue = true;

        playerControl.Enable();
    }
}
