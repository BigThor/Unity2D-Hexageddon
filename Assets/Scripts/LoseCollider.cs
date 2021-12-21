using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(PlayerLives.Instance == null)
        {
            Debug.LogError("PlayerLives is not instantiated");
            SceneLoader.Instance.LoadGameOverScene();
            return;
        }
            
        PlayerLives.Instance.LoseLife();
        if(PlayerLives.Instance.HasPlayerLost())
        {
            SceneLoader.Instance.LoadGameOverScene();
        }
        else
        {
            SceneLoader.Instance.ReloadScene();
        }
    }


}
