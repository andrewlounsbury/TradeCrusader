using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityManager : MonoBehaviour
{
    //public variables 
    //List of resource scriptable objects 
    public string CityName;
    public int CityFavor = 0;
    //private variables
    [SerializeField] public Dictionary<Resource, int> resourceList = new();
    [SerializeField] public List<Resource> resources = new List<Resource>();
    [SerializeField] public List<int> resourceAmount = new List<int>();
    [SerializeField] private List<int> resourceReplenish = new List<int>();
    
    [SerializeField] public float demandRate;

    [SerializeField] public CityDemands cityDemands; 
    [SerializeField] private Player player;

    public Node cityNode;
    private List<int> resourceCap = new List<int>();
    //On start clone the scriptable objects data, so you can alter it without writing to disk
    private float timer = 24; 

    private void Start()
    {
        //populates the dictionary
        for(int i = 0; i < resources.Count; i++)
        {
            resourceList.Add(resources[i], resourceAmount[i]);
        }

        resourceCap.AddRange(resourceAmount);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            int index = 0; 
            foreach (Resource resource in resources)
            {
                resourceList[resource] += resourceReplenish[index];

                if (resourceList[resource] > resourceCap[index])
                {
                    resourceList[resource] = resourceCap[index];
                }

                index++;
            }
            timer = 24; 
        }

    }

    public void BeginVoyage()
    {
        player.SetTargetNode(cityNode);
    }

    //function to alter the value of a specified scriptable object
    public void Buy(Resource resource, int amount)
    {
        if (resourceList.ContainsKey(resource) && resourceList[resource] >= amount && player.GetPlayerPurse().CanRemoveGold(amount * resource.buyRate))
        {
            player.GetPlayerPurse().RemoveGold(amount * resource.buyRate);
            resourceList[resource] -= amount; 
            player.GetPlayerCargo().AddResource(resource, amount);
        }
    }


    public void Sell(Resource resource, int amount)
    {
        if(cityDemands.MetCurrentDemand(resource, amount))
        {
            amount = cityDemands.currentDemandCount[cityDemands.currentDemands.IndexOf(resource)];
        }

        if (player.GetPlayerCargo().RemoveResource(resource, amount))
        {
            foreach(Resource demand in cityDemands.resources)
            {
                if (resource == demand)
                {
                    cityDemands.AddDemandResource(resource, amount);
                    player.GetPlayerPurse().AddGold(amount * resource.sellRate * demandRate);
                    return; 
                }
            }

            player.GetPlayerPurse().AddGold(amount * resource.sellRate);
        }

        if(cityDemands.MetCurrentDemand(resource, amount))
        {
            amount = cityDemands.currentDemandCount[cityDemands.currentDemands.IndexOf(resource)];
        }
    }

    public int ResourceAmount(Resource resource)
    {
        if (resourceList.ContainsKey(resource))
        {
            return resourceList[resource];
        }

        return -1;
    }
}
