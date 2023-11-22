using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public List <ResourceDisplay> inventorySlots;
    public CityManager cityManager;

    public void SetResourceDsiplay()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Image slot = inventorySlots[i].GetComponent<Image>();

            if (cityManager.resources.Count > i)
            {
                slot.sprite = cityManager.resources[i].icon;
                slot.color = new Color(1, 1, 1, 1);
                inventorySlots[i].resource = cityManager.resources[i];
            }
            else
            {
                slot.sprite = null;
                slot.color = new Color(1, 1, 1, 0);
                inventorySlots[i].resource = null;
            }
        }
    }
}
