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

    [SerializeField] private GameObject _atLocationPanel;
    [SerializeField] private GameObject _notAtLocationPanel;
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
        //toggle.Toggle(); 

        if (isClicked)
        {
            toggle.isMoving = true;
            _atLocationPanel.SetActive(false);
            _notAtLocationPanel.SetActive(true);
            toggle.OpenPanel();
            locationDisplay.SelectCity(GetComponent<CityManager>());
            isClicked = false; 
        }

    }

    void OnMouseDown()
    {
        if (GetComponent<CityManager>().cityNode == locationDisplay.player.GetCurrentNode())
        {
            _atLocationPanel.SetActive(true);
            _notAtLocationPanel.SetActive(false);
        }
        else
        {
            isClicked = true;
        }

        var locations = FindObjectsOfType<LocationSelect>();

        foreach (var location in locations)
        {
            location.spriteRenderer.sprite = originalSprite;
            transform.localScale = originalScale;
        }

        spriteRenderer.sprite = clickSprite;
        transform.localScale = originalScale * clickedScale;
    }

 //private void MovePanel(Vector2 targetPosition)
 //{
 //    Vector2 currentPosition = panelTransform.anchoredPosition;
 //    panelTransform.anchoredPosition = Vector2.Lerp(currentPosition, targetPosition, Time.deltaTime * moveSpeed);
 //
 //    if (Vector2.Distance(currentPosition, targetPosition) < 1f)
 //    {
 //        panelTransform.anchoredPosition = targetPosition;
 //        isOnScreen = !isOnScreen;
 //        isMoving = false;
 //    }
 //}



    //need to turn back sprite if click on anoother location
    //spriteRenderer.sprite = originalSprite;

}
