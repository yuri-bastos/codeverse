using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VariableTypes : ILevelType
{
    #region Fields
    [SerializeField]
    private List<SnappingSocket> sockets = new List<SnappingSocket>(){ };
    #endregion

    #region Variables
    public int completedSockets = 0;
    public int totalSockets = 0;
    private int correctSockets = 0;
    #endregion

    #region Events
    public UnityEvent _onVictory = new UnityEvent();
    public UnityEvent<int> _onStart = new UnityEvent<int>();
    public UnityEvent onVictory
    {
        get { return _onVictory; }
    }
    public UnityEvent<int> onStart
    {
        get { return _onStart; }
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
    }

    void incrementSockets(bool isCorrect)
    {
        completedSockets++;
        if(isCorrect)
        {
            correctSockets++;
        }
        if(correctSockets == totalSockets)
        {
            _onVictory.Invoke();
        }
    }

    void decrementSockets(bool isCorrect)
    {
        completedSockets--;
        if(isCorrect)
        {
            correctSockets--;
        }
    }
}
