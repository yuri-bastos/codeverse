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
    private bool shouldBeIncrementing = false;
    #endregion

    private void Start()
    {
        level.onVictory.AddListener(stopTimer);
        elapsedTime = 0f;
        shouldBeIncrementing = true;
    }

    void Update()
    {
        if(shouldBeIncrementing)
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void stopTimer()
    {
        shouldBeIncrementing = false;
    }
}
