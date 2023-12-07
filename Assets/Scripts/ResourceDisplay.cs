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
          
    public TMP_Text buyText;
    public TMP_Text sellText;
    public TMP_Text amountText;
    public TMP_Text wpuText;

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
            if (cityManager)
            {
                amountText.text = cityManager.ResourceAmount(resource).ToString();
                nameText.text = resource.name;

            }
            else
            {
                amountText.text = player.ResourceAmount(resource).ToString();
                nameText.text = resource.name;
            }
        }
    }
    //hi this is carson

    private void OnMouseOver()
    {

        if (resource == null) return;

        nameText.text = resource.name;

        wpuText.text = resource.weightPerUnit.ToString() + " /unit"; 

        rateText.text = resource.buyRate.ToString() + " G";

        player.currentResource = resource;
    }

    private void OnMouseExit()
    {
        if (!cityManager)
        {
            wpuText.text = "Total: " + player.GetPlayerCargo().GetTotalWeight().ToString() + "/" + player.GetPlayerCargo().maxWeight;
        }
    }

    public void ResetTexts()
    {
        wpuText.text = "weight";
        nameText.text = "name";
        rateText.text = "";
    }
}
