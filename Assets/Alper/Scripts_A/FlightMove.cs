using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightMove : MonoBehaviour
{
    public float speed = 10f;
    public float rotationn = 45f;
    private Camera cam;
    private float distance;
    private Vector3 velocity, lastPosition, rotation, touchposition, screenToWorld;
    private Rigidbody rb;
    public Transform visualChild;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
        distance = (cam.transform.position - transform.position).y;
    }

    void FixedUpdate()
    {
        velocity = transform.position - lastPosition;
        Move();
        lastPosition = transform.position;
    }
    void Move()
    {
        touchposition = Input.mousePosition;
        touchposition.z = distance;
        screenToWorld = cam.ScreenToWorldPoint(touchposition);

        Vector3 movement = Vector3.Lerp(rb.position, screenToWorld, speed * Time.fixedDeltaTime);
        rb.MovePosition(movement);

        rotation.z = -velocity.x * rotationn;
        rb.MoveRotation(Quaternion.Euler(rotation));
    }
}
