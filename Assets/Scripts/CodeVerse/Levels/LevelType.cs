using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ILevelType : MonoBehaviour
{
   public UnityEvent onVictory { get; }
   public UnityEvent<int> onStart { get;  }
}
