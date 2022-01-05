using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUIOnclick : MonoBehaviour
{
    [SerializeField] GameObject objectToHide;
    
    public void Hide()
    {
        if(objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
    }
}
