using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectMenuManager : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject modeSelectMenu;
    public VariableTypes level;

    [Header("Buttons")]
    public Button freeButton;
    public Button lifeButton;
    public Button timeButton;

    void Start()
    {
        freeButton.onClick.AddListener(loadFreeMode);
        lifeButton.onClick.AddListener(loadLifeMode);
        timeButton.onClick.AddListener(loadTimeMode);
    }

    public void loadFreeMode()
    {
        level.changeMode("free");
        HideAll();
    }

    public void loadLifeMode()
    {
        level.changeMode("life");
        HideAll();
    }

    public void loadTimeMode()
    {
        level.changeMode("time");
        HideAll();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideAll()
    {
        modeSelectMenu.SetActive(false);
    }
}
