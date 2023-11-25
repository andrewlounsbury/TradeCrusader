using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    [Header("Variables")]
    public Transform Target;
    public Vector3 CameraOffset;
    public float Speed;
    Vector3 velocity = Vector3.zero;
    public float MoveSpeed = 5.0f;

    [Header("Camera clamping")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private bool followPlayer = false;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

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

    public void ToggleFollow()
    {
        followPlayer = !followPlayer;
    }

    private void FollowPlayer()
    {
        if (Target != null)
        {
            Vector3 targetPosition = Target.position + CameraOffset;
            targetPosition.x = Mathf.Clamp(targetPosition.x, xMin, xMax);
            targetPosition.y = Mathf.Clamp(targetPosition.y, yMin, yMax);
            targetPosition.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
        }
    }

    public void MoveWithDirectionals(Vector3 moveDirection)
    {
        moveDirection.Normalize();

        transform.Translate(moveDirection * MoveSpeed * Time.deltaTime);

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
}