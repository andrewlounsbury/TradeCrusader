using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceDisplay : MonoBehaviour
{
    public Resource resource;
    public CityManager cityManager;
    public Player player;

    public TMP_Text nameText;
    public TMP_Text rateText;

    public TMP_Text amountText;
    public TMP_Text amountTextBuyPanel;
    public TMP_Text amountTextSellPanel;
    public TMP_Text wpuText;

    [SerializeField] private GameObject inactiveButton;
    [SerializeField] private GameObject activeButton;
    [SerializeField] private Resource noneResource;
    public bool isDemand = false;
    [SerializeField] private bool isPlayerResource; 

    // Start is called before the first frame update
    /*  void Start()
      {
          nameText.text = resource.name;
          wpuText.text = resource.weightPerUnit.ToString();
      }

      // Update is called once per frame
      void Update()
      {
          buyText.text = resource.buyRate.ToString();
          sellText.text = resource.sellRate.ToString();
          //amountText.text = resource.amount.ToString();
      }*/

    private void Update()
    {
        if (resource != null)
        {
            if (cityManager && !isPlayerResource)
            {
                if (isDemand) // SELLING INVENTORY 
                {
                    int index = cityManager.cityDemands.currentDemands.IndexOf(resource);

                    if (index < 0) return;

                    amountText.text = cityManager.cityDemands.currentDemandCount[index].ToString();
                    amountTextBuyPanel.text = cityManager.cityDemands.currentDemandCount[index].ToString();
                    amountTextSellPanel.text = cityManager.cityDemands.currentDemandCount[index].ToString();
                }
                else // BUYING INVENTORY 
                {
                    amountText.text = cityManager.ResourceAmount(resource).ToString();
                    amountTextBuyPanel.text = cityManager.ResourceAmount(player.currentResource).ToString();
                    amountTextSellPanel.text = player.ResourceAmount(player.currentResource).ToString();
                }
            }
            else // PLAYER INVENTORY 
            {
                amountText.text = player.ResourceAmount(resource).ToString();

                if (player.ResourceAmount(resource) == 0)
                {
                    resource = noneResource;
                    GetComponent<Image>().sprite = null;
                }
            }
            nameText.text = resource.name;


        }
    }
    //hi this is carson

    private void OnMouseOver()
    {
        if (resource == null) return;

        if (activeButton && inactiveButton)
        {
            activeButton.SetActive(true);
            inactiveButton.SetActive(false);
        }


        nameText.text = resource.name;

        wpuText.text = resource.weightPerUnit.ToString() + " /unit";

        if (!isPlayerResource)
        {
            rateText.text = resource.buyRate.ToString() + " G";
        }
    }

    private void OnMouseDown()
    {
        player.currentResource = resource;
    }

    private void OnMouseExit()
    {
        if (isPlayerResource)
        {
            wpuText.text = player.GetPlayerCargo().GetTotalWeight().ToString() + "/" + player.GetPlayerCargo().maxWeight;
        }
        
    }

    public void ResetTexts()
    {
        wpuText.text = "0 /unit";
        nameText.text = "name";
        rateText.text = "0 G";
    }
}
