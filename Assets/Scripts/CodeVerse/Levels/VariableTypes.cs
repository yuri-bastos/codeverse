using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VariableTypes : ILevelType
{
    #region Fields
    [SerializeField]
    private List<SnappingSocket> sockets = new List<SnappingSocket>() { };
    [SerializeField]
    private TMP_Text objectText;

    [SerializeField]
    private TMP_Text lifeText;

    [SerializeField]
    public string levelMode = "free";

    public Timer timer;

    #endregion

    #region Variables
    public int life = 3;

    public int completedSockets = 0;
    public int totalSockets = 0;
    private int correctSockets = 0;
    #endregion

    #region Events
    public UnityEvent<int> _onStart = new UnityEvent<int>();
    public UnityEvent<string> _onVictory = new UnityEvent<string>();
    public UnityEvent<string> _onDefeat = new UnityEvent<string>();
    public UnityEvent<int> onStart
    {
        get { return _onStart; }
    }
    public UnityEvent<string> onVictory
    {
        get { return _onVictory; }
    }

    public UnityEvent<string> onDefeat
    {
        get { return _onDefeat; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        totalSockets = sockets.Count;
        sockets.ForEach((socket) =>
        {
            socket.SocketFilled.AddListener((isCorrect) => incrementSockets(isCorrect));
            socket.SocketEmptied.AddListener((isCorrect) => decrementSockets(isCorrect));
        });
        _onStart.Invoke(1);
        lifeText.text = "";

        objectText.text = $"Objetos: {correctSockets} / {totalSockets}";
    }

    public void changeMode(string mode)
    {
        levelMode = mode;
        timer.setMode(mode);
        if (mode == "life") {
            lifeText.text = $"Vidas: {life}";
        } else {
            lifeText.text = "";
        }
    }

    void incrementSockets(bool isCorrect)
    {
        completedSockets++;
        if (isCorrect)
        {
            correctSockets++;
        }
        else
        {
            Debug.Log("Errou!");
            life--;
            if(levelMode == "life") {
                lifeText.text = $"Vidas: {life}";
            }
            if (life == 0 && levelMode == "life")
            {
                finish(false);
            }
        }
        objectText.text = $"Objetos: {correctSockets} / {totalSockets}";
        if (correctSockets == totalSockets)
        {
            objectText.text = $"Vitoria!";
            finish(true);
        }
    }

    void decrementSockets(bool isCorrect)
    {
        completedSockets--;
        if (isCorrect)
        {
            correctSockets--;
        }
        objectText.text = $"Objetos: {correctSockets} / {totalSockets}";
    }
    
    public void finish(bool isVictory)
    {
        var time = timer.stopTimer();
        var errors = 3 - life;
        string result = $"{time}\n - {errors} erros";
        if (isVictory)
        {
            onVictory.Invoke(result);
        }
        else {
            onDefeat.Invoke(result);
        }
    }
}
