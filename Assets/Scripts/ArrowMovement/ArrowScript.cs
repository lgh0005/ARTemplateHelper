using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int maxMoveIndex = 6;
    public int currentIndex = 0;

    private float initPosition = 3.6f;
    public float decrementAmount = 1.2f;

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, initPosition);
    }

    public void MoveToNext()
    {
        if (currentIndex < maxMoveIndex)
        {
            currentIndex++;
            UpdatePosition();
        }
    }

    public void MoveToPrev()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initPosition - (currentIndex * decrementAmount));
    }
}
