using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMiniScenes : MonoBehaviour
{
    private int MiniSceneCount;
    private int currentSceneIndex = 0;

    void Start()
    {
        MiniSceneCount =  this.transform.childCount - 1;
    }

    public void GotoMainScene()
    {
        currentSceneIndex = 0;
    }

    public void SelectedScene(int index)
    {
        currentSceneIndex = index;
    }

    void Update()
    {
        for (int i = 0; i <= MiniSceneCount; i++)
        {
            if (i == currentSceneIndex)
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
