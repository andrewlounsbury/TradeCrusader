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
    [SerializeField] private Dictionary<Resource, int> resourceList = new();
    [SerializeField] public List<Resource> resources = new List<Resource>();
    [SerializeField] private List<int> resourceAmount = new List<int>();

    [SerializeField] private Player player;
    public Node cityNode;
    //On start clone the scriptable objects data, so you can alter it without writing to disk


    private void Start()
    {
        //populates the dictionary
        for(int i = 0; i < resources.Count; i++)
        {
            resourceList.Add(resources[i], resourceAmount[i]);
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

    public void Buy(Resource resource)
    {
        //make variable for resource stack amount instaead of flat 10 
        Buy(resource, 10 );
    }

    public void Sell(Resource resource, int amount)
    {
        if (resourceList.ContainsKey(resource) && player.GetPlayerCargo().RemoveResource(resource, amount))
        {
            player.GetPlayerPurse().AddGold(amount * resource.sellRate);
            resourceList[resource] += amount; 
        }
    }

    public void Sell(Resource resource)
    {
        Sell(resource, 10);
    }

    private int ResourceAmount(Resource resource)
    {
        if (resourceList.ContainsKey(resource))
        {
            return resourceList[resource];
        }

        return -1;
    }
}
