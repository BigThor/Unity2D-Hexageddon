using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private string mainMenuKey = "Start Menu";
    private string gameOverKey = "Game Over";

    private static SceneLoader _instance;
    public static SceneLoader Instance { 
        get
        {
            if (_instance == null && SceneManager.GetActiveScene() != null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<SceneLoader>();
            }
            return _instance;
        } 
    }

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(mainMenuKey);
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverKey);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public bool IsCurrentSceneALevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        return !( currentScene.Equals(mainMenuKey) || 
                  currentScene.Equals(gameOverKey) );
    }
    private void OnDisable()
    {
        if (_instance != null)
        {
            Destroy(_instance.gameObject);
        }
    }

    private void OnDestroy()
    {
        if(_instance != null)
        {
            Destroy(_instance.gameObject);
        }
    }
}
