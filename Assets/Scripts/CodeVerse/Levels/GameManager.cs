using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadMainMenu()
    {
        SceneController.Instance.LoadScene("MainMenu");
    }

    void loadModuleScene(int moduleToLoad)
    {
        SceneController.Instance.LoadScene($"Module_{moduleToLoad}");
    }

    void onLevelFinish()
    {
        Debug.Log($"Level {currentModule} finished!");
    }
}
