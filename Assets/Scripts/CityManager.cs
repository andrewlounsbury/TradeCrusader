using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CityManager : MonoBehaviour
{
    //public variables 
    //List of resource scriptable objects 

    //private variables
    [SerializeField] private Dictionary<Resource, int> resourceList = new();
    [SerializeField] private List<Resource> resources = new List<Resource>();
    [SerializeField] private List<int> resourceAmount = new List<int>();
    //On start clone the scriptable objects data, so you can alter it without writing to disk


    private void Start()
    {
        //populates the dictionary
        for(int i = 0; i < resources.Count; i++)
        {
            resourceList.Add(resources[i], resourceAmount[i]);
        }
    }

    //function to alter the value of a specified scriptable object
    public void Buy(Resource resource, int amount)
    {
        if (resourceList.ContainsKey(resource) && resourceList[resource] >= amount)
        {
            resourceList[resource] -= amount; 
        }
    }

    public void Buy(Resource resource)
    {
        if (resourceList.ContainsKey(resource) && resourceList[resource] >= 10)
        {
            resourceList[resource] -= 10;
        }
    }

    public void Sell(Resource resource, int amount)
    {
        if (resourceList.ContainsKey(resource))
        {
            resourceList[resource] += amount; 
        }
    }

    public void Sell(Resource resource)
    {
        if (resourceList.ContainsKey(resource))
        {
            Debug.Log(resourceList[resource]);
            resourceList[resource] += 10;
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
}
