using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LocationDisplay : MonoBehaviour
{

    public CityManager currentCity;
    public TMP_Text locationName;
    public Slider favor;
    public Image flag; 
    public CityInventory inventory;
    public CityInventory demandsInventory;

    public Player player;

    public void SelectCity(CityManager city)
    {
        currentCity = city;
        inventory.cityManager = currentCity;
        demandsInventory.cityManager = currentCity;
        ResetText();
        UpdateDisplayData();
    }

    public void ArriveAtCity(CityManager city)
    {
/*        currentCity = city;
        inventroy.cityManager = currentCity;
        {
            UpdateDisplayData();
        }*/
    }

    public void UpdateDisplayData()
    {
        if (currentCity)
            locationName.text = currentCity.CityName;
        //favor.Image = currentCity.CityFavor.ToString();
        
        if(currentCity && player.GetCurrentNode() != currentCity.cityNode)
        {
            inventory.SetResourceDisplay();
            demandsInventory.SetDemandsDisplay();
            return;
        }

        if(player.ISBuying())
            inventory.SetResourceDisplay();

        if (demandsInventory && player.IsSelling())
        {
            demandsInventory.SetDemandsDisplay();
        }
    }

    public void BeginVoyage()
    {
        player.SetTargetNode(currentCity.cityNode);
    }

    public void ResetText()
    {
        inventory.ResetTexts();
    }
}
