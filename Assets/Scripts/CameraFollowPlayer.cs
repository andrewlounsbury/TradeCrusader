using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [Header ("Variables")]
    public Transform target;
    public Vector3 cameraOffset;
    public float speed; 
    Vector3 velocity = Vector3.zero;

    [Header ("Camera clampling")]
    public float xMin; 
    public float xMax;
    public float yMin;
    public float yMax;


    // Update is called once per frame
    private void FixedUpdate()
    {
        float xClamp = Mathf.Clamp(target.position.x, xMin, xMax);
        float yClamp = Mathf.Clamp(target.position.y, yMin, yMax);

        Vector3 targetPosition = target.position + cameraOffset;
        Vector3 clampedPosition = new Vector3(Mathf.Clamp(targetPosition.x, xMin, xMax), Mathf.Clamp(targetPosition.y, yMin, yMax), - 1);
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, clampedPosition, ref velocity, speed * Time.deltaTime);

        transform.position = smoothPosition;
    }
}