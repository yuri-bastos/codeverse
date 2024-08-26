using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    #region Fields
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] VariableTypes level;
    #endregion

    #region Variables
    float elapsedTime = 0f;
    float maxTime = 480f;
    float availableTime = 480f;
    private bool shouldBeIncrementing = false;
    private string levelMode = "free";

    #endregion

    private void Start()
    {
        elapsedTime = 0f;
    }

    void Update()
    {
        if (shouldBeIncrementing)
        {
            elapsedTime += Time.deltaTime;
            if (levelMode == "time")
            {
                availableTime = maxTime - elapsedTime;
                int minutes = Mathf.FloorToInt(availableTime / 60);
                int seconds = Mathf.FloorToInt(availableTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

                if (availableTime <= 0f)
                {
                    shouldBeIncrementing = false;
                    level.finish(false);
                }
            }
            else
            {
                int minutes = Mathf.FloorToInt(elapsedTime / 60);
                int seconds = Mathf.FloorToInt(elapsedTime % 60);
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }


        }
    }

    public void setMode(string mode)
    {
        levelMode = mode;
        shouldBeIncrementing = true;
    }

    public string stopTimer()
    {
        shouldBeIncrementing = false;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        string result = string.Format("{0:00}:{1:00}", minutes, seconds);
        return result;
    }
}
