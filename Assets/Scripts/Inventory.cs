using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public List <ResourceDisplay> inventorySlots;
    public CityManager cityManager;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Image slot = inventorySlots[i].GetComponent<Image>();

            if (cityManager.resources.Count > i)
            {
                slot.sprite = cityManager.resources[i].icon;
                inventorySlots[i].resource = cityManager.resources[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
