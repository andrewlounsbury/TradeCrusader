using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen;
    [SerializeField] private GameObject buttonToHide;
    [SerializeField] private GameObject buttonToShow;
    //public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private Color selectedColor;

    public void Select()
    {
        DynamicPanelManager.Instance.ActivatePanel(panelToOpen);
        buttonToHide.SetActive(false);
        buttonToShow.SetActive(true);
    }
}
