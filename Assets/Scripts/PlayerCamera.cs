using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector3 velocity = Vector3.zero;
    public float cameraSmoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.position - offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, cameraSmoothSpeed * Time.deltaTime);
    }
}
