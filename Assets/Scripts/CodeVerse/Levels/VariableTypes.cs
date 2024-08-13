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
    #endregion

    #region Variables
    public int life = 3;

    public int completedSockets = 0;
    public int totalSockets = 0;
    private int correctSockets = 0;
    #endregion

    #region Events
    public UnityEvent _onVictory = new UnityEvent();
    public UnityEvent _onDefeat = new UnityEvent();
    public UnityEvent<int> _onStart = new UnityEvent<int>();
    public UnityEvent onVictory
    {
        get { return _onVictory; }
    }
    public UnityEvent<int> onStart
    {
        get { return _onStart; }
    }

    public UnityEvent onDefeat
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

        objectText.text = $"Objetos: {correctSockets} / {totalSockets}";
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
            lifeText.text = $"Vidas: {life}";
            if (life == 0)
            {
                onDefeat.Invoke();
            }
        }
        objectText.text = $"Objetos: {correctSockets} / {totalSockets}";
        if (correctSockets == totalSockets)
        {
            objectText.text = $"Vitoria!";
            _onVictory.Invoke();
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
}
