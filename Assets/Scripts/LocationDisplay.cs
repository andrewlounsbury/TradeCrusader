using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class LocationDisplay : MonoBehaviour
{

    public CityManager currentCity;
    public TMP_Text locationName;
    public Slider favor;
    public Image flag; 
    public CityInventory inventroy;

    public Player player;

    public void SelectCity(CityManager city)
    {
        currentCity = city;
        inventroy.cityManager = currentCity;

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

    private void UpdateDisplayData()
    {
        locationName.text = currentCity.CityName;
        //favor.Image = currentCity.CityFavor.ToString();

        inventroy.SetResourceDsiplay();
    }

    public void BeginVoyage()
    {
        player.SetTargetNode(currentCity.cityNode);
    }
}
