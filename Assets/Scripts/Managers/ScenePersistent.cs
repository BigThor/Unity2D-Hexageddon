using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersistent : MonoBehaviour
{
    [SerializeField] private static int currentScene;
    private static ScenePersistent _instance;

    private void Awake()
    {
        if(_instance == null || currentScene != SceneManager.GetActiveScene().buildIndex)
        {
            _instance = this;
            currentScene = SceneManager.GetActiveScene().buildIndex;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(!SceneLoader.Instance.IsCurrentSceneALevel())
        {
            Destroy(gameObject);
            _instance = null;
        }
    }

    private void OnDisable()
    {
        if(this == _instance)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
