using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSelf : MonoBehaviour
{
    public void TurnOff()
    {
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void TurnOn()
    {
        this.gameObject.SetActive(true);
    }
}
