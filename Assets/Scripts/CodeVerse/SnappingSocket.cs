using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class SnappingSocket : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private string socketName;

    [SerializeField]
    private XRSocketInteractor ThisSocketInteractor;

    [SerializeField]
    private string expectedInformation;
    #endregion

    #region Variables
    private bool isCorrect = false;
    #endregion

    #region Events
    public UnityEvent<bool> SocketFilled;
    public UnityEvent<bool> SocketEmptied;
    #endregion
    void Start()
    {
        ThisSocketInteractor.selectEntered.AddListener((args) => checkObject());
        ThisSocketInteractor.selectExited.AddListener((args) => removedObject());
    }

    void checkObject()
    {
        Debug.Log($"Socket {socketName} is Now Occupied");
        IXRSelectInteractable selected = ThisSocketInteractor.GetOldestInteractableSelected();
        var info = selected.transform.GetComponent<InteractableObject>().ObjectInformation;
        Debug.Log($"Information = {info}");

        if(info == expectedInformation)
        {
            Color color;
            ColorUtility.TryParseHtmlString("#00FF00", out color);
            transform.parent.parent.Find("Text/Type Text/Text").GetComponent<TMP_Text>().color = color;
            Debug.Log("Correct Socket!");
            isCorrect = true;
            SocketFilled.Invoke(true);
        }
        else
        {
            Color color;
            ColorUtility.TryParseHtmlString("#FF0000", out color);
            transform.parent.parent.Find("Text/Type Text/Text").GetComponent<TMP_Text>().color = color;
            Debug.Log("Incorrect Socket!");
            isCorrect = false;
            SocketFilled.Invoke(false);
        }   

    }

    void removedObject()
    {
        Color color;
        ColorUtility.TryParseHtmlString("#FFFFFF", out color);
        transform.parent.parent.Find("Text/Type Text/Text").GetComponent<TMP_Text>().color = color;
        Debug.Log("Removed from Socket!");
        SocketEmptied.Invoke(isCorrect);
        isCorrect = false;
    }
}
