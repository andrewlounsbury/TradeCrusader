using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradePanelCancel : MonoBehaviour
{
    
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;

    private void Start()
    {
        /*panelToClose.SetActive(false);
        panelToClose2.SetActive(false);
        buttonToShow.SetActive(false);
        buttonToHide.SetActive(false);*/

    }

    public void Cancel()
    {
        if (panel1.activeInHierarchy) 
        {
            button1.SetActive(true);
            button2.SetActive(false);
        }
        else if(panel2.activeInHierarchy)
        {
            button1.SetActive(false);
            button2.SetActive(true);
        }

        panel1.SetActive(false);
        panel2.SetActive(false);

        gameObject.SetActive(false);
    }
}
