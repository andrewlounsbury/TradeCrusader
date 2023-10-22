using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    [Header("Variables")]
    public Transform target;
    public Vector3 cameraOffset;
    public float speed;
    Vector3 velocity = Vector3.zero;
    public float moveSpeed = 5.0f;
    public bool followPlayer = false;

    [Header("Camera clampling")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);

        if (moveDirection.magnitude > 0.01f)
        {
            followPlayer = false;
        }

        if (!followPlayer)
        {
            MoveWithDirectionals(moveDirection);
        }
        else
        {
            FollowPlayer();
        }
    }

    public void SetShouldFollowPlayer(bool shouldFollow) => followPlayer = shouldFollow;

    private void FollowPlayer()
    {
        //TODO: Implement follow player controls
    }

    public void MoveWithDirectionals(Vector3 moveDirection)
    {
        moveDirection.Normalize();

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);


        if (transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }

        if (transform.position.y < yMin)
        {
            transform.position = new Vector3(transform.position.x, yMin, transform.position.z);
        }
        else if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x, yMax, transform.position.z);
        }
    }

    //private void FixedUpdate()
    //{
    //    float xClamp = Mathf.Clamp(target.position.x, xMin, xMax);
    //    float yClamp = Mathf.Clamp(target.position.y, yMin, yMax);
    //
    //    Vector3 targetPosition = target.position + cameraOffset;
    //    Vector3 clampedPosition = new Vector3(Mathf.Clamp(targetPosition.x, xMin, xMax), Mathf.Clamp(targetPosition.y, yMin, yMax), -1);
    //    Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity, speed * Time.deltaTime);
    //
    //    transform.position = smoothPosition;
    //}
    //

}
