using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicPanelManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPanel;
    [SerializeField] private GameObject LocationSelectPanel;
    [SerializeField] private GameObject BuySellPanel;
    [SerializeField] private GameObject BuyPanel;
    [SerializeField] private GameObject SellPanel;
    [SerializeField] private List<GameObject> extraPanels;
    public static DynamicPanelManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(this);
    }

    public void ActivatePlayerPanel()
    {
        playerPanel.SetActive(true);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        foreach(GameObject panel in extraPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ActivateLocationSelectPanel()
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(true);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        foreach (GameObject panel in extraPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ActiveBuySellPanel()
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(true);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        foreach (GameObject panel in extraPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ActivateBuyPanel()
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(true);
        SellPanel.SetActive(false);
        foreach (GameObject panel in extraPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ActivateSellPanel()
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(true);
        foreach (GameObject panel in extraPanels)
        {
            panel.SetActive(false);
        }
    }

    public void ActivateDialoguePanel()
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        for (int i = 0; i < extraPanels.Count; i++)
        {
            extraPanels[i].SetActive(i == 0); //0 == index in editor
        }
    }

    public void ActivatePanel(GameObject panelToActivate)
    {
        playerPanel.SetActive(playerPanel == panelToActivate);
        LocationSelectPanel.SetActive(LocationSelectPanel == panelToActivate);
        BuySellPanel.SetActive(BuySellPanel == panelToActivate);
        BuyPanel.SetActive(BuyPanel == panelToActivate);
        SellPanel.SetActive(SellPanel == panelToActivate);
        foreach(GameObject panel in extraPanels)
        {
            panel.SetActive(panel == panelToActivate);
        }
    }

    public void ActivatePanel(int index)
    {
        playerPanel.SetActive(false);
        LocationSelectPanel.SetActive(false);
        BuySellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        SellPanel.SetActive(false);
        for(int i = 0; i < extraPanels.Count; i++)
        {
            extraPanels[i].SetActive(i == index);
        }
    }
}
