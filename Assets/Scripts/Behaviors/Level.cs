using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int iHexagonCount;

    
    void Awake()
    {
        // Initialization on Awake so hexagons count
        // themeselves after at Start()
        iHexagonCount = 0;
    }

    public void AddOneToHexagonCount()
    {
        iHexagonCount++;
    }

    public void BlockDestroyed()
    {
        if (--iHexagonCount <= 0)
        {
            SceneLoader.Instance.LoadNextScene();
        }
    }
}
