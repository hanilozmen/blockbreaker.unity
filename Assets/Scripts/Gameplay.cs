using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public int boxCount;

    public void IncreaseBoxCount()
    {
        boxCount++;
    }

    public void DecreaseBoxCount()
    {
        boxCount--;
        if (boxCount <= 0)
            FindObjectOfType<SceneLoader>().LoadNextScene();
    }
}
