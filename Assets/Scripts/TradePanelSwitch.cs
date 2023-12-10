using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePanelSwitch : MonoBehaviour
{
    [SerializeField] private GameObject panelToOpen;
    [SerializeField] private GameObject panelToClose;
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;
    [SerializeField] private GameObject buttonToHide2;

    private void Start()
    {
        /*buttonToShow.SetActive(false);
        buttonToHide.SetActive(false);
        buttonToHide2.SetActive(false);
*/
    }

    public void OpenBuy()
    {
        panelToOpen.SetActive(true);
        panelToClose.SetActive(false);
        buttonToShow.SetActive(true);
        buttonToHide.SetActive(false);
        buttonToHide2.SetActive(false);
    }


    public void OpenSell()
    {
        panelToOpen.SetActive(true);
        panelToClose.SetActive(false);
        buttonToShow.SetActive(true);
        buttonToHide.SetActive(false);
        buttonToHide2.SetActive(false);
    }

/*    public void Cancel()
    {
        panelToOpen.SetActive(false);
        panelToClose.SetActive(false);
        buttonToShow.SetActive(false);
        buttonToHide.SetActive(false);
        buttonToHide2.SetActive(false);
    }*/
}
