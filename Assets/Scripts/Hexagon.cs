using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField] int hexagonHP = 1;
    [SerializeField] AudioClip destroySound;

    private Level currentLevel;


    // Start is called before the first frame update
    void Start()
    {
        currentLevel = FindObjectOfType<Level>();
        currentLevel.AddOneToHexagonCount();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == "Ball")
        {
            if (--hexagonHP > 0)
                return;

            AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
            currentLevel.BlockDestroyed();
            Destroy(gameObject);
        }
    }
}
