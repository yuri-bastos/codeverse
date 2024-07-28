using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableObject : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private Transform ThisTransform;

    [SerializeField]
    private GameObject HoverInfoPrefab;

    [SerializeField]
    private string ObjectName = "";

    [SerializeField]
    private string ObjectDescription = "";

    [SerializeField]
    public string ObjectInformation = "";
    #endregion

    #region Variables
    private GameObject ObjectInfoPanel = null;
    private XRGrabInteractable interactable;
    private Camera mainCamera;
    #endregion

    #region Methods
    void Start()
    {
        mainCamera = Camera.main;
        interactable = ThisTransform.GetComponent<XRGrabInteractable>();
        interactable.hoverEntered.AddListener((p) => OnHoverObject());
        interactable.hoverExited.AddListener((p) => OnStopHoverObject());
    }

    private void Update()
    {
        if(ObjectInfoPanel != null)
        {
            ObjectInfoPanel.transform.rotation = Quaternion.Slerp(ObjectInfoPanel.transform.rotation, mainCamera.transform.rotation, 1);
        }
    }

    void OnHoverObject()
    {
        if(ObjectInfoPanel != null)
        {
            OnStopHoverObject();
        }
        ObjectInfoPanel = GameObject.Instantiate(HoverInfoPrefab, ThisTransform);
        ObjectInfoPanel.transform.rotation = Quaternion.Slerp(ObjectInfoPanel.transform.rotation, mainCamera.transform.rotation, 1);
        ObjectInfoPanel.transform.Find("Title").GetComponent<TMP_Text>().text = ObjectName;
        ObjectInfoPanel.transform.Find("Info").GetComponent<TMP_Text>().text = ObjectDescription;
    }

    void OnStopHoverObject()
    {
        GameObject.Destroy(ObjectInfoPanel);
        ObjectInfoPanel = null;
    }
    #endregion
}
