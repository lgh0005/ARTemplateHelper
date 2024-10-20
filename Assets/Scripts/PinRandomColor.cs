using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
    public Material[] materials;

    void Start()
    {
        if (materials.Length > 0)
        {
            int randomIndex = Random.Range(0, materials.Length);
            GetComponent<Renderer>().material = materials[randomIndex];
        }
    }
}
