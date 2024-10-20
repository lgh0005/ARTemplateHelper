using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBackground : MonoBehaviour
{
    void Start()
    {
        ChangeBackground();
    }

    private void ChangeBackground()
    {
        int childCount = transform.childCount;

        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        int randomIndex = Random.Range(0, childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}