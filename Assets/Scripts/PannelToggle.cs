using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelToggle : MonoBehaviour
{

    private bool isActive = false;
    void Start()
    {
        this.gameObject.SetActive(isActive);
    }

    public void ToggleSelf()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}
