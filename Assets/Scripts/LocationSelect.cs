using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationSelect : MonoBehaviour
{
    public Sprite clickSprite;
    public float clickedScale = 1.5f;
    public RectTransform panelTransform;
    public Vector2 onScreenPosition;
    public Vector2 offScreenPosition;
    public float moveSpeed = 5.0f;

    private bool isClicked = false;
    private bool isOnScreen = false;
    private Vector3 originalScale;
    [HideInInspector] public Sprite originalSprite;
    [HideInInspector] public SpriteRenderer spriteRenderer;

    [SerializeField] private LocationTabButton locationTabButton; 
    [SerializeField] private PanelToggle toggle;
    [SerializeField] private LocationDisplay locationDisplay;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;

        panelTransform.anchoredPosition = offScreenPosition;

        toggle.isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClicked)
        {
            toggle.isMoving = true;
            toggle.OpenPanel();
            locationDisplay.SelectCity(GetComponent<CityManager>());
            locationTabButton.UpdatePanels();
            isClicked = false; 
        }
    }

    void OnMouseDown()
    {
        isClicked = true;

        var locations = FindObjectsOfType<LocationSelect>();

        foreach (var location in locations)
        {
            location.spriteRenderer.sprite = location.originalSprite;
            transform.localScale = location.originalScale;
        }

        spriteRenderer.sprite = clickSprite;
        transform.localScale = originalScale * clickedScale;
    }

}
