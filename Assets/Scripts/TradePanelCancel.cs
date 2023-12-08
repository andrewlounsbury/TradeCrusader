using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePanelCancel : MonoBehaviour
{
    
    [SerializeField] private GameObject panelToClose;
    [SerializeField] private GameObject panelToClose2;
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;

    private void Start()
    {
        /*panelToClose.SetActive(false);
        panelToClose2.SetActive(false);
        buttonToShow.SetActive(false);
        buttonToHide.SetActive(false);*/

    }

    public void Cancel()
    {
        panelToClose2.SetActive(true);
        panelToClose.SetActive(false);
        buttonToShow.SetActive(true);
        buttonToHide.SetActive(true);
    }

}
