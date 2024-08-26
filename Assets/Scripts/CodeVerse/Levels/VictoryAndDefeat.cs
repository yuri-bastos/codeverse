using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryAndDefeat : MonoBehaviour
{
    [Header("UI Pages")]
    public GameObject thisScreen;
    public GameManager gameManager;

    [Header("Texts")]
    public TMP_Text points;

    [Header("Buttons")]
    public Button retryButton;
    public Button backButton;

    void Start()
    {
        retryButton.onClick.AddListener(reloadLevel);
        backButton.onClick.AddListener(returnToMenu);
    }

    public void Initialize(string result)
    {
        thisScreen.SetActive(true);
        points.text = result;
    }

    public void reloadLevel()
    {
        HideAll();
        gameManager.restartModule();
    }

    public void returnToMenu()
    {
        HideAll();
        gameManager.loadMainMenu();
    }

    public void HideAll()
    {
        thisScreen.SetActive(false);
    }
}
