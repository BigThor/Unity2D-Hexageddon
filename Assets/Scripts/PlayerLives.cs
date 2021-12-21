using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLives : SceneLoadedActor
{
    [SerializeField] TMP_Text livesText;

    [SerializeField] int startingLives = 3;

    private int currentLives;

    private static PlayerLives _instance;
    public static PlayerLives Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLives = startingLives;
        UpdateText();
    }

    // Update is called once per frame
    void UpdateText()
    {
        livesText.text = "x " + currentLives.ToString("D2");
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateText();
    }

    public bool HasPlayerLost()
    {
        return currentLives < 0;
    }

    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(!SceneLoader.Instance.IsCurrentSceneALevel())
            Destroy(gameObject);
    }
}
