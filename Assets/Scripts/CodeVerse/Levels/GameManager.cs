using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int currentModule = 0;
    [SerializeField]
    public VictoryAndDefeat victoryPanel;
    [SerializeField]
    public VictoryAndDefeat defeatPanel;

    public VariableTypes level;

    // Start is called before the first frame update
    void Start()
    {
        level.onStart.AddListener((levelNo) => { currentModule = levelNo; });
        level.onVictory.AddListener((result) => {onLevelVictory(result);});
        level.onDefeat.AddListener((result) => {onLevelDefeat(result);});
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void loadModuleScene(int moduleToLoad)
    {
        SceneManager.LoadScene($"Module_{moduleToLoad}");
    }

    public void restartModule()
    {
        SceneManager.LoadScene($"Module_{currentModule}");
    }

    void onLevelVictory(string result)
    {
        Debug.Log($"Level {currentModule} finished!");
        victoryPanel.Initialize(result);
    }

    void onLevelDefeat(string result)
    {
        Debug.Log($"Level {currentModule} finished!");
        defeatPanel.Initialize(result);
    }
}
