using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CityDemands : MonoBehaviour
{
    [SerializeField] public List<Resource> resources;
    [SerializeField] private Vector2Int materialRange = new Vector2Int(50, 100);
    [SerializeField] private Vector2Int foodRange = new Vector2Int(50, 100);
    [SerializeField] private Vector2Int luxuryRange = new Vector2Int(30, 75);
    [SerializeField] private Vector2Int uniqueRange = new Vector2Int(1, 20);
    [SerializeField] private Player player;
    [HideInInspector] public List<Resource> currentDemands = new(3);
    [HideInInspector] public List<int> currentDemandCount = new(3);

    private void Start()
    {
        StartCoroutine(PickNewDemand(0));
        StartCoroutine(PickNewDemand(0));
        StartCoroutine(PickNewDemand(0));
    }

    public bool MetCurrentDemand(Resource resource, int amount)
    {
        return IsDemandingResource(resource) && currentDemandCount[currentDemands.IndexOf(resource)] <= amount;
    }

    private bool IsDemandingResource(Resource resource) => currentDemands.IndexOf(resource) >= 0;

    public bool AddDemandResource(Resource resource, int amount)
    {
        if(MetCurrentDemand(resource, amount))
        {
            currentDemands.Remove(resource);

            StartCoroutine(PickNewDemand(0)); //input float for time to refresh demand
            return true;
        }

        currentDemandCount[currentDemands.IndexOf(resource)] -= amount;

        return false;
    }

    private IEnumerator PickNewDemand(float time)
    {
        yield return new WaitForSeconds(time);
        int index = Random.Range(0, resources.Count);

        if (index < 0)
            yield break;

        if(resources[index].category != null && resources[index].category.Count > 0)
        {
             currentDemands.Add(resources[index]);

            switch (resources[index].category[0])
            {
                case ResourceCategory.UNIQUE:
                    currentDemandCount.Add(Random.Range(uniqueRange.x, uniqueRange.y));
                    break;
                case ResourceCategory.LUXURY:
                    currentDemandCount.Add(Random.Range(luxuryRange.x, luxuryRange.y));
                    break;
                case ResourceCategory.FOOD:
                    currentDemandCount.Add(Random.Range(foodRange.x, foodRange.y));
                    break;
                case ResourceCategory.MATERIAL:
                    currentDemandCount.Add(Random.Range(materialRange.x, materialRange.y));
                    break;
                default:
                    currentDemandCount.Add(Random.Range(materialRange.x, materialRange.y));
                    break;
            }
        }
        else
        {
            currentDemandCount.Add(Random.Range(materialRange.x, materialRange.y));
        }


    }
}
