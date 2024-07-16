using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    public GameObject[] resourcePrefab; // Array of prefabs to instantiate
    public int resourceCount = 20; // Number of resources to spawn
    public Vector3 spawnAreaSize = new Vector3(50, 1, 50); // Size of the spawn area

    void Start()
    {
        for (int i = 0; i < resourceCount; i++)
        {
            // Generate a random spawn position within spawnAreaSize
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                0,
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
            );

            // Randomly select a prefab from resourcePrefab array
            GameObject selectedPrefab = resourcePrefab[Random.Range(0, resourcePrefab.Length)];

            // Instantiate the selected prefab at the generated spawn position
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
