using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class PrefabCreator : MonoBehaviour
{
    public GameObject dragonPrefab;
    public Vector3 prefabOffset;
    private ARTrackedImageManager trackedImageManager;

    void OnEnable()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }
    }

    void OnDisable()
    {
        if (trackedImageManager != null)
        {
            trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            // Spawn the dragon at the position of the tracked image
            Instantiate(dragonPrefab, trackedImage.transform.position + prefabOffset, trackedImage.transform.rotation);
        }
    }
}
