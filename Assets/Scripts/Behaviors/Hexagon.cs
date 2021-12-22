using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hexagon : SceneLoadedActor
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip destroySound;
    [SerializeField] ParticleSystem hitParticlesPrefab;

    [SerializeField] HexagonColor startingColor;

    [SerializeField] private int currentHexagonHP;
    private Level currentLevel;

    enum HexagonColor
    {
        Green = 1,
        Yellow,
        Orange,
        Red,
        Pink,
        Purple
    };
    
    // Start is called before the first frame update
    void Start()
    {
        currentHexagonHP = (int)startingColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Ball")
        {
            SpawnHitParticles();
            if (--currentHexagonHP > 0)
            {
                UpdateColor((HexagonColor)currentHexagonHP);
                return;
            }

            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

    private void SpawnHitParticles()
    {
        ParticleSystem newParticles = Instantiate(hitParticlesPrefab);
        newParticles.transform.position = transform.position; 

        ParticleSystem.MainModule settings = newParticles.main;
        settings.startColor = spriteRenderer.color;
        newParticles.Play();
    }

    private void UpdateColor(HexagonColor newHexagonColor)
    {
        Color updatedColor = Color.green;
        switch(newHexagonColor)
        {
            case HexagonColor.Green:
                updatedColor = new Color(0.365f, 1.0f, 0.145f);
                break;
            case HexagonColor.Yellow:
                updatedColor = new Color(1.0f, 0.953f, 0.145f);
                break;
            case HexagonColor.Orange:
                updatedColor = new Color(1.0f, 0.4f, 0.145f);
                break;
            case HexagonColor.Red:
                updatedColor = new Color(1.0f, 0.172f, 0.145f);
                break;
            case HexagonColor.Pink:
                updatedColor = new Color(1.0f, 0.145f, 0.6f);
                break;
            case HexagonColor.Purple:
                updatedColor = new Color(0.765f, 0.145f, 1.0f);
                break;
        }
        spriteRenderer.color = updatedColor;
    }

    private void OnValidate()
    {
        UpdateColor(startingColor);
    }

    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentLevel = FindObjectOfType<Level>();

        if(currentLevel != null)
        {
            currentLevel.AddOneToHexagonCount();
        }
        else
        {
            Debug.LogWarning("Level instance not found in scene");
        }
    }

    private void OnDestroy()
    {
        if (currentLevel != null)
        {
            currentLevel.BlockDestroyed();
        }
    }
}
