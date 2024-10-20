using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlitImages : MonoBehaviour
{
    private ArrowScript arrowScript;

    public GameObject arrowObject;
    public GameObject guideObject;

    private int stateIndex;

    void Start()
    {
        arrowScript = arrowObject.GetComponent<ArrowScript>();
    }

    void Update() 
    {
        if (arrowScript != null)
        {
            stateIndex = arrowScript.currentIndex;
            UpdateChildrenVisibility();
        }  
    }

    void UpdateChildrenVisibility()
    {
        int index = 0;
        foreach (Transform child in guideObject.transform)
        {
            if (index == stateIndex)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            index++;
        }
    }

    public void ResetChildrenVisibility()
    {
        foreach (Transform child in guideObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
}
