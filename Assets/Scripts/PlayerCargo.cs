using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCargo : MonoBehaviour
{
    [SerializeField] public Dictionary<Resource, int> resourceList = new();
    [SerializeField] public List<Resource> resources = new List<Resource>();
    [SerializeField] public List<int> resourceAmount = new List<int>();
    [SerializeField] private float minSpeed = 1;
    [SerializeField] private float maxSpeed = 1;
    [SerializeField] private Player player; 
    public float maxWeight = 200;

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
        float totalWeight = GetTotalWeight() + resource.weightPerUnit * amount;
        return totalWeight <= maxWeight;
    }

    public bool RemoveResource(Resource resource, int amount)
    {
        if (CanRemoveResource(resource, amount))
        {
            resourceList[resource] -= amount;

            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i] == resource)
                {
                    resourceAmount[i] -= amount;
                }
                if (resourceAmount[i] <= 0)
                {
                    resources.RemoveAt(i);
                    resourceAmount.RemoveAt(i);
                }
            }

            

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
            resources.Add(resource);
            resourceAmount.Add(amount);
        }

        player.SetSpeed(maxSpeed * (1 - (GetTotalWeight() / maxWeight)) + minSpeed); 

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
