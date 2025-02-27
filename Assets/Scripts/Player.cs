using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Node currentNode;
    [SerializeField] private Node targetNode;
    [SerializeField] private LocationDisplay locationDisplay;
    [SerializeField] private BreadthFirstSearch BFS;
    [SerializeField] private TMP_Text sellAmountText;
    [SerializeField] private TMP_Text buyAmountText;
    private bool isMoving = false;

    [SerializeField] private PlayerPurse playerPurse;
    [SerializeField] private PlayerCargo cargo;

    [SerializeField] private float moveSpeed = 3;

    public TMP_Text buyText;
    public TMP_Text sellText;
    public BuySellPanel buyAndSellPanel;
    public CityDialogue cityDialogue;
    public PanelToggle panelToggle;

    public Resource currentResource; 
    private int exchangeAmount = 0;
    private bool isBuying = true; 

    private void Start()
    {
        transform.position = currentNode.transform.position;
    }

    private void Update()
    {
        MoveToTarget();

        if(currentResource)
        {
            sellText.text = "Sell " + currentResource.name;
            buyText.text = "Buy " + currentResource.name;
        }

        locationDisplay.UpdateDisplayData();

        Quit();
    }

    public PlayerPurse GetPlayerPurse() => playerPurse;
    public PlayerCargo GetPlayerCargo() => cargo;
    public bool IsSelling() => !isBuying;
    public bool ISBuying() => isBuying;
    
    public void SetTargetNode(Node target)
    {
        if (isMoving)
        {
            return; 
        }

        if (targetNode != target)
        {
            isMoving = true; 
        }

        targetNode = target; 
    }

    private void MoveToTarget()
    {
        // Return if not moving
        if (!isMoving) return;

        // Create chart if needed
        if (BFS.PathChart.Count == 0 && targetNode)
        {
            BFS.BFS(targetNode);
        }

        // Check if you need to set next node
        if (Vector3.Distance(transform.position, currentNode.transform.position) <= 0.01f)
        {
            currentNode = BFS.PathChart[currentNode];
        }

        // Move
        transform.position = Vector3.MoveTowards(transform.position, currentNode.transform.position, moveSpeed * Time.deltaTime); 
        
        // Check if you've hit your goal
        if (Vector3.Distance(transform.position, targetNode.transform.position) <= 0.01f)
        {
            isMoving = false;
            DynamicPanelManager.Instance.ActivateDialoguePanel();
            BFS.PathChart.Clear();
            panelToggle.isMoving = true; 
            panelToggle.OpenPanel();
            buyAndSellPanel.currentCity = targetNode.GetComponentInChildren<CityManager>();
            cityDialogue.SetDialogueTree(targetNode.GetComponentInChildren<DialogueTree>());
            cityDialogue.SetText();
        }

    }

    public void Quit()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit Successfully");
        }
    }

    internal Node GetTargetNode()
    {
        return targetNode;
    }

    public Node GetCurrentNode()
    {
        return currentNode;
    }

    public void IncreaseExchangeAmount(int amount)
    {
        if (!currentResource) return;


        exchangeAmount += amount;
        int v;
        if (isBuying)
        {
            v = targetNode.GetComponentInChildren<CityManager>().ResourceAmount(currentResource);
        }
        else
        {
            v = ResourceAmount(currentResource);
        }

        if (exchangeAmount > v)
        {
            exchangeAmount = v;
        }
        sellAmountText.text = exchangeAmount.ToString();
        buyAmountText.text = exchangeAmount.ToString();
    }

    public void DecreaseExchangeAmount(int amount)
    {
        if (!currentResource) return;

        exchangeAmount -= amount;

        if (exchangeAmount < 0)
        {
            exchangeAmount = 0;
        }
        buyAmountText.text = exchangeAmount.ToString();
        sellAmountText.text = exchangeAmount.ToString();
    }

    public void RemoveResource(Resource resource, int amount)
    {
        if(GetPlayerCargo() != null) 
        {
            cargo.RemoveResource(resource, amount);
        }
    }

    public void Sell()
    {
        CityManager city = targetNode.GetComponentInChildren<CityManager>();
        city.Sell(currentResource, exchangeAmount); 
    }

    public void Buy()
    {
        if (cargo.CanAddResource(currentResource, exchangeAmount))
        {
            CityManager city = targetNode.GetComponentInChildren<CityManager>();
            city.Buy(currentResource, exchangeAmount);
        }

    }

    public int ResourceAmount(Resource resource)
    {
        if (cargo.resourceList.ContainsKey(resource))
        {
            return cargo.resourceList[resource];
        }

        for (int i = 0; i < cargo.resources.Count; i++)
        {
            if (cargo.resources[i] == resource)
            {
                return cargo.resourceAmount[i];
            }
        }

        return 0;
    }

    public void PlayerIsBuying() => isBuying = true;
    public void PlayerIsSelling() => isBuying = false;
    public void ResetExchangeAmount() => exchangeAmount = 0;
    //handle clicking of node in its own function here
    //whwenever node is clickeed, do BFS.BFS

    public void SetSpeed(float speed)
    {
        moveSpeed = speed; 
    }
}
