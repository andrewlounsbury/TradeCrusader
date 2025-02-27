using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationButton : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private LocationDisplay locationDisplay;
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;
    /*public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private Color selectedColor;*/

    public void Selected()
    {
        UpdatePanels();
    }

    public void UpdatePanels()
    {
        if (player.GetCurrentNode() == locationDisplay.currentCity.cityNode)
        {
            DynamicPanelManager.Instance.ActiveBuySellPanel();
            buttonToShow.SetActive(true);
        }
        else
        {
            DynamicPanelManager.Instance.ActivateLocationSelectPanel();
            buttonToShow.SetActive(true);
        }
       // transform.localScale = originalScale;
    }

    void OnMouseExit()
    {
       // transform.localScale = originalScale;
    }
}
