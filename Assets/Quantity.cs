using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Quantity : MonoBehaviour
{
    public static Quantity instance;

    public int currentObjects = 0;
    public TMP_Text objectText;

    void Awake() {
        instance = this;
    }

    void Start() {
        objectText.text = "OBJETOS: " + currentObjects.ToString();
    }

    void increaseObjects(int v) {
        currentObjects += v;
        objectText.text = "OBJETOS: " + currentObjects.ToString();
    }
}
