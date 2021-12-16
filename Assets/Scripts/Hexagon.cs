using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip destroySound;

    [SerializeField] HexagonColor startingColor;

    private int currentHexagonHP = 1;
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
        currentLevel = FindObjectOfType<Level>();
        currentLevel.AddOneToHexagonCount();

        //spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (--currentHexagonHP > 0)
            {
                UpdateColor((HexagonColor)currentHexagonHP);
                return;
            }

            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            currentLevel.BlockDestroyed();
            Destroy(gameObject);
        }
    }

    private void UpdateColor(HexagonColor newHexagonColor)
    {
        //spriteRenderer.color
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
        Debug.Log("Last color: " + spriteRenderer.color);
        Debug.Log("New color: " + updatedColor);
        spriteRenderer.color = updatedColor;
        Debug.Log("Color check: " + spriteRenderer.color);
    }

    private void OnValidate()
    {
        UpdateColor(startingColor);
    }
}
