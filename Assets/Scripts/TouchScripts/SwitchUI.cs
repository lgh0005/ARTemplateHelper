using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUI : MonoBehaviour
{
    private bool isActive;
    void Start()
    {
        this.gameObject.SetActive(isActive);
    }

    public void TurnOnSelf()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}
