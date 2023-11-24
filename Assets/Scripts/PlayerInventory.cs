using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerInventory : MonoBehaviour
{
    public List<ResourceDisplay> inventorySlots;
    public PlayerCargo playerCargo;

    private void Update()
    {
        SetResourceDsiplay();
    }

    public void SetResourceDsiplay()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            Image slot = inventorySlots[i].GetComponent<Image>();

            if (playerCargo.resources.Count > i)
            {
                slot.sprite = playerCargo.resources[i].icon;
                slot.color = new Color(1, 1, 1, 1);
                inventorySlots[i].resource = playerCargo.resources[i];
            }
/*            else
            {
                slot.sprite = null;
                slot.color = new Color(1, 1, 1, 0);
                inventorySlots[i].resource = null;
            }*/
        }
    }
}
