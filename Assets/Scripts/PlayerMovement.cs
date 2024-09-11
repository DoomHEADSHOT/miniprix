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

        transform.Translate(transform.forward * vertical * Time.deltaTime);
        transform.Translate(transform.right * -horizontal * Time.deltaTime);

        targetDirection = Vector3.zero;
        targetDirection = Camera.transform.forward * vertical;
        targetDirection += Camera.transform.right * horizontal;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if(targetDirection == Vector3.zero)
        {
            targetDirection = transform.forward;
        }

        Quaternion newRotation = Quaternion.LookRotation(targetDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        transform.rotation = targetRotation;

        HandleFollowTarget();

        /*vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0)
        {
            transform.Translate(new Vector3(-2 * horizontal * Time.deltaTime, 0f, 0f));

        }
        else if (vertical != 0)
        {
            transform.Translate(new Vector3(0, 0, -2 * vertical * Time.deltaTime));
        }*/


        //transform.Rotate((transform.up * horizontal) * rotationSpeed * Time.fixedDeltaTime);
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
