using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LocationHover : MonoBehaviour
{
    public float hoverScale = 1.2f; 

    private Vector3 originalScale;


    void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.localScale = originalScale * hoverScale;
    }
    
    void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

}
