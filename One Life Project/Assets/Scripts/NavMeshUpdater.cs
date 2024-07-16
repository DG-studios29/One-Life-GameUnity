using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshUpdater : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;
    public float checkInterval = 1f; // Interval in seconds to check for changes
    private float checkTimer;

    private List<GameObject> trackedObjects = new List<GameObject>();

    void Start()
    {
        if (navMeshSurface == null)
        {
            navMeshSurface = FindObjectOfType<NavMeshSurface>(); // Find the NavMeshSurface in the scene
        }

        // Find and track all objects of interest (e.g., Resource objects)
        Resource[] resources = FindObjectsOfType<Resource>();
        foreach (Resource resource in resources)
        {
            trackedObjects.Add(resource.gameObject);
        }
    }

    void Update()
    {
        checkTimer += Time.deltaTime;

        if (checkTimer >= checkInterval)
        {
            checkTimer = 0f;
            CheckAndRebuildNavMesh();
        }
    }

    void CheckAndRebuildNavMesh()
    {
        bool needsRebuild = false;

        // Check if any tracked objects have been destroyed
        for (int i = trackedObjects.Count - 1; i >= 0; i--)
        {
            if (trackedObjects[i] == null)
            {
                trackedObjects.RemoveAt(i);
                needsRebuild = true;
            }
        }

        if (needsRebuild && navMeshSurface != null)
        {
            navMeshSurface.BuildNavMesh();
        }
    }

    // Method to add a tracked object (e.g., when a new resource is spawned)
    public void TrackObject(GameObject obj)
    {
        trackedObjects.Add(obj);
    }
}
