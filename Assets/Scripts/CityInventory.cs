using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CityInventory : MonoBehaviour
{
    [SerializeField] private Color baseSlotColor;
    public List <ResourceDisplay> inventorySlots;
    public CityManager cityManager;
    public TMP_Text resourceName;

    public void SetResourceDisplay()
    {
        foreach (ResourceDisplay resource in inventorySlots)
        {
            resource.isDemand = false;
        }

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Image slot = inventorySlots[i].GetComponent<Image>();

            if (cityManager.resources.Count > i)
            {
                slot.sprite = cityManager.resources[i].icon;
                slot.color = new Color(1, 1, 1, 1);
                inventorySlots[i].cityManager = cityManager;
                inventorySlots[i].resource = cityManager.resources[i];
                inventorySlots[i].amountText.text = cityManager.resourceAmount[i].ToString();
            }
            else
            {
                slot.sprite = null;
                slot.color = baseSlotColor;
                inventorySlots[i].resource = null;
                inventorySlots[i].amountText.text = "";
            }
        }
    }

    public void SetDemandsDisplay()
    {
        foreach(ResourceDisplay resource in inventorySlots)
        {
            resource.isDemand = true;
        }

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Image slot = inventorySlots[i].GetComponent<Image>();

            if (cityManager.cityDemands.currentDemands.Count > i)
            {
                slot.sprite = cityManager.cityDemands.currentDemands[i].icon;
                slot.color = new Color(1, 1, 1, 1);
                inventorySlots[i].cityManager = cityManager;
                inventorySlots[i].resource = cityManager.cityDemands.currentDemands[i];
                inventorySlots[i].amountText.text = cityManager.cityDemands.currentDemandCount[i].ToString();
            }
            else
            {
                slot.sprite = null;
                slot.color = baseSlotColor;
                inventorySlots[i].resource = null;
                inventorySlots[i].amountText.text = "";
            }
        }
    }

    public void ResetTexts()
    {
        foreach (var slot in inventorySlots)
        {
            slot.amountText.text = "";
            slot.ResetTexts();
        }
    }
}
