using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

    void Start()
    {
        // Initialize resources dictionary
        foreach (ResourceType resourceType in System.Enum.GetValues(typeof(ResourceType)))
        {
            resources[resourceType] = 0;
        }
    }

    public void AddResource(ResourceType resourceType, int amount)
    {
        resources[resourceType] += amount;
        Debug.Log("Added " + amount + " of " + resourceType + ". Total: " + resources[resourceType]);
        // Update UI or other game elements
    }

    public bool HasResource(ResourceType resourceType, int amount)
    {
        return resources[resourceType] >= amount;
    }

    public void RemoveResource(ResourceType resourceType, int amount)
    {
        if (resources[resourceType] >= amount)
        {
            resources[resourceType] -= amount;
            Debug.Log("Removed " + amount + " of " + resourceType + ". Remaining: " + resources[resourceType]);
            // Update UI or other game elements
        }
        else
        {
            Debug.LogWarning("Not enough " + resourceType + " to remove.");
        }
    }

    public int GetResourceCount(ResourceType resourceType)
    {
        return resources[resourceType];
    }
}
