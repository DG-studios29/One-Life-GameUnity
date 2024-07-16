using UnityEngine;

public enum ResourceType
{
    Wood,
    Stone,
    Metal,
    Food,
    Water
}

public class Resource : MonoBehaviour
{
    public ResourceType resourceType;
    public int quantity = 10;

    void Start()
    {
        NavMeshUpdater navMeshUpdater = FindObjectOfType<NavMeshUpdater>();
        if (navMeshUpdater != null)
        {
            navMeshUpdater.TrackObject(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Implement resource collection logic
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddResource(resourceType, quantity);
                Destroy(gameObject);
            }
        }
    }
}
