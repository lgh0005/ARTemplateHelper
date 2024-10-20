using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildActivator : MonoBehaviour
{
    private void Start()
    {
        ActivateRandomChild();
    }

    private void ActivateRandomChild()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;

        for (int i = 0; i < childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        int randomIndex = Random.Range(0, childCount);

        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
