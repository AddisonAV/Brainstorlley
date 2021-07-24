using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlTrap : MonoBehaviour
{
    public UnityEvent resetTrap;

    public void ReActivate()
    {
        resetTrap.Invoke();
    }
}
