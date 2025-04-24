using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class PlayButton : UIHandler
{
    
    private Button buttontoDisable;
  
    private void Start()
    {
        buttontoDisable = GetComponent<Button>();

        if (buttontoDisable != null)
        {
            buttontoDisable.interactable = false;
        }
        if (inputField != null)
        {
            inputField.onValueChanged.AddListener(OnPlayerNamePut);
        }
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
    private void OnPlayerNamePut(string playerName) 
    {
        if (buttontoDisable != null)
        {
            buttontoDisable.interactable = !string.IsNullOrWhiteSpace(playerName);
        }
    }
    public override void OnButtonClick() 
    {
        string playerName = inputField.text;
        if (!string.IsNullOrWhiteSpace(playerName)) {
            SceneManager.LoadScene("Main Game");
        }
    }
}
