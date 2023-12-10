using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerPurse : MonoBehaviour
{
    //variables
    [SerializeField] private float currentGold;
    [SerializeField] private TextMeshProUGUI purseText;

    // Start is called before the first frame update
    void Start()
    {
        purseText.text = currentGold + " G";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddGold(float amount)
    {
        currentGold += amount;
        purseText.text = currentGold.ToString() + " G";
    }

    public void RemoveGold(float amount)
    {
        currentGold -= amount;
        purseText.text = currentGold.ToString() + " G";
    }

    public bool CanRemoveGold(float amount)
    {
        if (currentGold >= amount) 
        {
            return true; 
        }
        return false;
    }

}
