using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelToggle : MonoBehaviour
{
    public RectTransform panelTransform;
    public Vector2 onScreenPosition;
    public Vector2 offScreenPosition;
    public float moveSpeed = 5.0f;

    private bool isOnScreen = false;
    public bool isMoving = false;

    private void Start()
    {
        // Ensure the panel starts in the off-screen position
        panelTransform.anchoredPosition = offScreenPosition;

        isMoving = false; 

    }

    private void Update()
    {
        Toggle();
    }

    private void MovePanel(Vector2 targetPosition)
    {
        Vector2 currentPosition = panelTransform.anchoredPosition;
        panelTransform.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, Time.deltaTime * moveSpeed);

        if (Vector2.Distance(currentPosition, targetPosition) < 1f)
        {
            panelTransform.anchoredPosition = targetPosition;
            isOnScreen = !isOnScreen;
            isMoving = false; 
        }
    }

    public void Toggle()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collider = GetComponent<Collider2D>();

            if (collider.OverlapPoint(mousePosition))
            {
                isMoving = true;
            }
        }

        if (isMoving)
        {
            if (isOnScreen)
            {
                MovePanel(offScreenPosition);
                gameObject.transform.localScale = new Vector3(45, -20, 0);
            }
            else
            {
                MovePanel(onScreenPosition);
                gameObject.transform.localScale = new Vector3(45, 20, 0);
            }
        }
    }

    public void OpenPanel()
    {

        if (isMoving)
        {
            MovePanel(onScreenPosition);
            gameObject.transform.localScale = new Vector3(45, 20, 0);
        }
    }

}
