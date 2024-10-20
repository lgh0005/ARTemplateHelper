using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

public class MultipleImageTracker : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;

    public GameObject[] placeablePrefabs;

    public GameObject objectHolder;

    Dictionary<string, GameObject> spawnedObjects;
    void Start()
    {
        spawnedObjects = new Dictionary<string, GameObject>();
        foreach(GameObject obj in placeablePrefabs)
        {
            GameObject newObject = Instantiate(obj, objectHolder.transform);
            newObject.name = obj.name;
            newObject.SetActive(false);
            spawnedObjects.Add(newObject.name, newObject);
        }
    }

    private void Update()
    {
        foreach (ARTrackedImage trackedImage in trackedImageManager.trackables)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                string referenceImageName = trackedImage.referenceImage.name;

                if (spawnedObjects.TryGetValue(referenceImageName, out GameObject prefab))
                {
                    prefab.transform.position = trackedImage.transform.position + new Vector3(0, 0.003f, 0);
                    prefab.transform.rotation = trackedImage.transform.rotation;
                    prefab.SetActive(true);
                }
            }

            else if (trackedImage.trackingState == TrackingState.Limited || trackedImage.trackingState == TrackingState.None)
            {
                string referenceImageName = trackedImage.referenceImage.name;

                if (spawnedObjects.TryGetValue(referenceImageName, out GameObject prefab))
                {
                    prefab.SetActive(false);
                }
            }
        }
    }

    void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateSpawnObject(trackedImage);
        }

        foreach(ARTrackedImage trackedImage in eventArgs.removed)
        {
            spawnedObjects[trackedImage.name].SetActive(false);
        }
    }

    void UpdateSpawnObject(ARTrackedImage trackedImage)
    {
        string referenceImageName = trackedImage.referenceImage.name;
        spawnedObjects[referenceImageName].transform.position = trackedImage.transform.position;
        spawnedObjects[referenceImageName].transform.rotation = trackedImage.transform.rotation;
        spawnedObjects[referenceImageName].SetActive(true);
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    public void MultipleImageTrackingSceneReload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
