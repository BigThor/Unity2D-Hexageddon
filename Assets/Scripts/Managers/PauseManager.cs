using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] Canvas pausedCanvas;
    [SerializeField] Canvas pauseButtonCanvas;

    private bool isPaused;

    // Start is called before the first frame update
    private void Start()
    {
        isPaused = false;
        pausedCanvas.enabled = false;
        pauseButtonCanvas.enabled = true;
        Time.timeScale = 1.0f;
    }

    public void PauseAction(InputAction.CallbackContext value)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            pausedCanvas.enabled = true;
            pauseButtonCanvas.enabled = false;
            Time.timeScale = 0.0f;
        }
        else
        {
            pausedCanvas.enabled = false;
            pauseButtonCanvas.enabled = true;
            Time.timeScale = 1.0f;
        }
    }
}
