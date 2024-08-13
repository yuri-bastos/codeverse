using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public int currentModule = 0;

    public VariableTypes level;

    // Start is called before the first frame update
    void Start()
    {
        level.onStart.AddListener((levelNo) => { currentModule = levelNo; });
        level.onVictory.AddListener(onLevelFinish);
        level.onDefeat.AddListener(restartModule);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void loadModuleScene(int moduleToLoad)
    {
        SceneManager.LoadScene($"Module_{moduleToLoad}");
    }

    void restartModule()
    {
        SceneManager.LoadScene($"Module_{currentModule}");
    }

    void onLevelFinish()
    {
        Debug.Log($"Level {currentModule} finished!");
    }
}
