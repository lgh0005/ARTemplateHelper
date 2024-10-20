using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSelf : MonoBehaviour
{
    private bool isActive;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void TurnOnSelf()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}