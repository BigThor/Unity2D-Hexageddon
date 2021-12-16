using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int iHexagonCount; // Serialized for debuggin purposes

    private SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddOneToHexagonCount()
    {
        iHexagonCount++;
    }

    public void BlockDestroyed()
    {
        if (iHexagonCount-- <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
