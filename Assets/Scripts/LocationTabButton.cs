using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationTabButton : MonoBehaviour
{
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject locationPanel;
    [SerializeField] private GameObject atLocationPanel;
    [SerializeField] private Player player;
    [SerializeField] private LocationDisplay locationDisplay;
    public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private Color selectedColor;

    // Start is called before the first frame update
    private void Start()
    {
        playerPanel.SetActive(false);
        locationPanel.SetActive(false);
        atLocationPanel.SetActive(false);
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.localScale = originalScale * hoverScale;
    }

    private void OnMouseDown()
    {
        UpdatePanels();
    }

    public void UpdatePanels()
    {
        if (player.GetCurrentNode() == locationDisplay.currentCity.cityNode)
        {
            playerPanel.SetActive(false);
            locationPanel.SetActive(false);
            atLocationPanel.SetActive(true);
        }
        else
        {
            playerPanel.SetActive(false);
            locationPanel.SetActive(true);
            atLocationPanel.SetActive(false);
        }
        transform.localScale = originalScale;
    }

    void OnMouseExit()
    {
        transform.localScale = originalScale;
    }
}
