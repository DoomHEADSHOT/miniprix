using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    PlayerControl playerControl;

    
    Vector3 targetDirection;
    [SerializeField] Camera Camera;
    //Vector2 inputMovement;
 
    // The Rigidbody attached to the GameObject.
    private Rigidbody body;
    /// <summary>
    /// Speed scale for the velocity of the Rigidbody.
    /// </summary>
    public float speed = 7;
    /// <summary>
    /// Rotation Speed scale for turning.
    /// </summary>
    public float rotationSpeed;
    // The vertical input from input devices.
    private float vertical;
    private float horizontal;

    public Vector2 inputMovement;

    private float cameraSmoothSpeed = 1; //THE BIGGER THIS NUMBER ,THE LONGER FOR THE CAMERA TO REACH ITS POSITION DURING MOVEMENT
    private Vector3 cameraVelocity;


    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = inputMovement.y;
        horizontal = inputMovement.x;

        Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y);

        if( movement != Vector3.zero )
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        //HandleFollowTarget();

    }

    private void HandleFollowTarget()
    {
        Vector3 targetCameraPosition = Vector3.SmoothDamp(Camera.transform.position, transform.position - new Vector3(0,-5,3), ref cameraVelocity, cameraSmoothSpeed * Time.deltaTime);
        Camera.transform.position = targetCameraPosition;
    }

    private void OnEnable()
    {
        playerControl = new PlayerControl();

        playerControl.PlayerMovement.Movement.performed += i => inputMovement = i.ReadValue<Vector2>();


        playerControl.Enable();
    }
}
