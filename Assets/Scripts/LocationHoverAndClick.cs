using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LocationHoverAndClick : MonoBehaviour
{
    public float hoverScale = 1.2f; 
    public Sprite clickSprite;

    private bool rotated = false;
    private bool isClicked = false;
    private Quaternion targetRotation;
    private float rotationSpeed = 5; 
    private Vector3 originalScale;
    private Sprite originalSprite;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
        targetRotation = transform.rotation;
    }

    void OnMouseEnter()
    {
        transform.localScale = originalScale * hoverScale;
    }
    
    void OnMouseExit()
    {
        transform.localScale = originalScale;
    
        spriteRenderer.sprite = originalSprite;
    }

    private void Update()
    {
        if (rotated && transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); 
        }
    }

    void OnMouseDown()
    {
        isClicked = true;

        transform.localScale = originalScale * hoverScale;
        spriteRenderer.sprite = clickSprite;
    }

    void OnMouseUp()
    {
        if (!rotated && isClicked == true)
        {
            transform.Rotate(0, 0, 360);
            rotated = true;
        }
    }
}
