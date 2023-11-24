using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitchButtons : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen;
    [SerializeField] private GameObject panelToClose1;
    [SerializeField] private GameObject panelToClose2;
    public float hoverScale = 1.2f;
    private Vector3 originalScale;
    private Color selectedColor;

    // Start is called before the first frame update
    private void Start()
    {
        panelToOpen.SetActive(false);
        panelToClose1.SetActive(false); 
        panelToClose2.SetActive(false);
        originalScale = transform.localScale;
    }

    void OnMouseEnter()
    {
        transform.localScale = originalScale * hoverScale;
    }

    private void OnMouseDown()
    {
        panelToOpen.SetActive(true);
        panelToClose1.SetActive(false);
        panelToClose2.SetActive(false);
        transform.localScale = originalScale;
    }
    void OnMouseExit()
    {
        transform.localScale = originalScale;
    }
}
