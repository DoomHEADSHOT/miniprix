using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    //PlayerControl playerControl;
    //Vector2 inputMovement;
 
    // The Rigidbody attached to the GameObject.
    private Rigidbody body;
    /// <summary>
    /// Speed scale for the velocity of the Rigidbody.
    /// </summary>
    public float speed;
    /// <summary>
    /// Rotation Speed scale for turning.
    /// </summary>
    public float rotationSpeed;
    // The vertical input from input devices.
    private float vertical;
    private float horizontal;
 
  
    Transform Transform;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        //transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
    }
    private void FixedUpdate()
    {
        if (horizontal != 0) {
            transform.position = (transform.position * horizontal) * speed;

        }
        else    if (vertical != 0) {
            transform.position = (transform.position * vertical) * speed;
        }

        if (horizontal >= 0)
        {
            Transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (horizontal <= 0)
        {
        
            Transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (vertical >= 0) 
        {
        
        }
        if(vertical <= 0)
        {
 
        }
    }

    private void OnEnable()
    {
        //playerControl = new PlayerControl();

        //playerControl.move.Forward.performed += i => inputMovement = i.ReadValue<Vector2>();
    }
}
