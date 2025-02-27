using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuySellPanel : MonoBehaviour
{
    public LocationDisplay buyDisplay;
    public LocationDisplay sellDisplay;

    public TMP_Text dialogueText;
    public CityManager currentCity;

    public float textSpeed = 0.05f;

    private void OnEnable()
    {
        StartCoroutine(Co_DisplayText());
    }

    IEnumerator Co_DisplayText()
    {
        dialogueText.text = "";

        foreach(char character in currentCity.tradingPhrase)
        {
            yield return new WaitForSeconds(textSpeed);
            dialogueText.text += character;
        }
    }

    public void OpenBuyPanel()
    {
        DynamicPanelManager.Instance.ActivateBuyPanel();

        FindObjectOfType<Player>().PlayerIsBuying();
        buyDisplay.SelectCity(currentCity);
    }

    public void OpenSellPanel()
    {
        DynamicPanelManager.Instance.ActivateSellPanel();

        FindObjectOfType<Player>().PlayerIsSelling();
        sellDisplay.SelectCity(currentCity);
    }
}
