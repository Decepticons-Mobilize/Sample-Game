using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] protected Button button;
    [SerializeField] protected TMPro.TMP_InputField inputField;
    [SerializeField] protected Image image;

    public virtual void OnButtonClick()
    {
        // Debug
    }
    public virtual void OnInputChange(string value) 
    { 
        // Debug
    }
    public virtual void OnInputFieldMouseEnter() { }
    public virtual void OnInputFieldMouseExit() { }
    
}
