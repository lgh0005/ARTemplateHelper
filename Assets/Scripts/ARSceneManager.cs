using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ARSceneManager : MonoBehaviour
    {
        void Awake()
        {
            if (FindObjectsOfType(GetType()).Length > 1) 
            {
                Destroy(gameObject);
            } 
            else 
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        void OnEnable()
        {
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        void OnSceneUnloaded(Scene current)
        {
            if (current == SceneManager.GetActiveScene())
            {
                LoaderUtility.Deinitialize();
                LoaderUtility.Initialize();
            }
        }

        void OnDisable()
        {
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}