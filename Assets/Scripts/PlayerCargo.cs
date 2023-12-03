using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCargo : MonoBehaviour
{
    [SerializeField] public Dictionary<Resource, int> resourceList = new();
    [SerializeField] public List<Resource> resources = new List<Resource>();
    [SerializeField] private List<int> resourceAmount = new List<int>();
    public float maxWeight = 100;

    // Start is called before the first frame update
    private void Start()
    {
        //populates the dictionary
        for (int i = 0; i < resources.Count; i++)
        {
            resourceList.Add(resources[i], resourceAmount[i]);
        }
    }

    public bool CanAddResource(Resource resource, int amount)
    {
        return GetTotalWeight() + resource.weightPerUnit * amount <= maxWeight;
    }

    public bool RemoveResource(Resource resource, int amount)
    {
        if (CanRemoveResource(resource, amount))
        {
            resourceList[resource] -= amount;
            return true; 
        }
        return false;
    }


    public void AddResource(Resource resource, int amount)
    {

        if (resourceList.ContainsKey(resource))
        {
            resourceList[resource] += amount;
        }
        else
        {
            resourceList.Add(resource, amount);
        }
    }

    private int ResourceAmount(Resource resource)
    {
        if (resourceList.ContainsKey(resource))
        {
            return resourceList[resource];
        }

        return -1;
    }

    private bool CanRemoveResource(Resource resource, int amount)
    {
        if (resourceList.ContainsKey(resource) && resourceList[resource] >= amount)
        {
            return true;
        }
        return false;
    }

    public float GetTotalWeight()
    {
        float totalWeight = 0f;
        foreach (var resource in resourceList)
        {
            totalWeight += resource.Key.weightPerUnit * resource.Value;
        }
        return totalWeight;
    }
}
