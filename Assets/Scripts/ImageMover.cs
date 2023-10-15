using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMover : MonoBehaviour
{
    public float speed = 2.0f;  // Adjust this to control the speed of movement
    private RectTransform imageTransform;
    private Vector3 targetPosition;

    private void Start()
    {
        imageTransform = GetComponent<RectTransform>();
        // Initialize the target position to the current position
        targetPosition = imageTransform.anchoredPosition;
    }

    private void Update()
    {
        // Move the image towards the target position
        imageTransform.anchoredPosition = Vector3.MoveTowards(imageTransform.anchoredPosition, targetPosition, speed * Time.deltaTime);

        // Check if the image has reached the target position
        if (Vector3.Distance(imageTransform.anchoredPosition, targetPosition) < 0.01f)
        {
            // Generate a new random target position within the menu screen boundaries
            targetPosition = new Vector3(Random.Range(-350, 350), Random.Range(-50, 50), 0);
        }
    }
}
