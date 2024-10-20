using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SceneChanger : MonoBehaviour
{
    private ARSession _arSession;
    private ARTrackedImageManager _trackedImageManager;

    [SerializeField]
    // 1. 관람 안내, 2.상징물 소개, 3. 전시관 소개
    public XRReferenceImageLibrary arScene1Library; 

    public XRReferenceImageLibrary arScene2Library;

    public XRReferenceImageLibrary arScene3Library;

    void Awake()
    {
        _arSession = FindObjectOfType<ARSession>();
        _trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("1_Menu", LoadSceneMode.Single);
    }

    public void GotoScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    InitializeARManager();
    SceneManager.sceneLoaded -= OnSceneLoaded;
}

    private void InitializeARManager()
    {
        if (_arSession != null)
        {
            _arSession.Reset();
        }

        if (_trackedImageManager != null)
        {
            _trackedImageManager.enabled = false;
            switch (SceneManager.GetActiveScene().name)
            {
                case "2_Visitor":
                    _trackedImageManager.referenceLibrary = arScene1Library;
                    break;

                case "3_Symbol":
                    _trackedImageManager.referenceLibrary = arScene2Library;
                    break;

                case "4_Exhibit":
                    _trackedImageManager.referenceLibrary = arScene3Library;
                    break;
                default:
                    _trackedImageManager.referenceLibrary = null;
                    break;
            }
            _trackedImageManager.enabled = true;
        }
    }
}