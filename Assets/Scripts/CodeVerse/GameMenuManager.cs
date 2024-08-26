using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject optionsMenu;
    public InputActionProperty showMenuButton;

    void Update()
    {
        if(showMenuButton.action.WasPerformedThisFrame())
        {
            optionsMenu.SetActive(false);
            menu.SetActive(!menu.activeSelf);
        }
        
    }
}
