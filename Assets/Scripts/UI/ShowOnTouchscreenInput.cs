using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShowOnTouchscreenInput : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        if (!playerInput.currentControlScheme.Equals("Touch"))
        {
            Destroy(gameObject);
        }
    }
}
