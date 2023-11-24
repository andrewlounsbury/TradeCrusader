using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCargo : MonoBehaviour
{
    [SerializeField] private Dictionary<Resource, int> resourceList = new();
    [SerializeField] public List<Resource> resources = new List<Resource>();
    [SerializeField] private List<int> resourceAmount = new List<int>();

    // Start is called before the first frame update
    private void Start()
    {
        //populates the dictionary
        for (int i = 0; i < resources.Count; i++)
        {
            resourceList.Add(resources[i], resourceAmount[i]);
        }
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
}
