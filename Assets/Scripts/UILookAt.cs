using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    void LateUpdate() 
    {
        Vector3 targetDirection = Camera.main.transform.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        transform.rotation = lookRotation;
    }
}
