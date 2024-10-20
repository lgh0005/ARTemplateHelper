using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateObject : MonoBehaviour
{
    private int maxInteractionStep;

    private int currentInteractionStep;

    void Start()
    {
        maxInteractionStep = this.transform.childCount - 1;
        currentInteractionStep = 0;
    }

    public void MoveToNext()
    {
        if (currentInteractionStep < maxInteractionStep)
        {
            currentInteractionStep++;
        }
    }

    public void MoveToPrev()
    {
        if (currentInteractionStep > 0)
        {
            currentInteractionStep--;
        }
    }

    void Update()
    {
        for (int i = 0; i <= maxInteractionStep; i++)
        {
            if (i == currentInteractionStep)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
