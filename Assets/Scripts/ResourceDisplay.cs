using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDisplay : MonoBehaviour
{
    public Resource resource; 
    public CityManager cityManager;

    public Text nameText;
    public Text buyText;
    public Text sellText;
    public Text amountText;
    public Text wpuText; 

    // Start is called before the first frame update
    void Start()
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
    }
}
