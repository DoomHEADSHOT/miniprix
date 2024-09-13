using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    PlayerControl playerControl;
    float interactionTrue;
    // Start is called before the first frame update
    public Transform InteractorSource;
    public float InteractRange;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (interactionTrue>0) {
            Debug.Log("E pressed");
        }
    }
    private void OnEnable()
    {
        playerControl = new PlayerControl();

        playerControl.Interact.Interaction.performed += i => interactionTrue = i.ReadValue<float>();

        playerControl.Enable();
    }
}
