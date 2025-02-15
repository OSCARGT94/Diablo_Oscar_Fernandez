using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="EventManager")]
public class EventManagerSO : ScriptableObject
{
    public event Action OnNuevaMIsion;
    internal void NuevaMIsion()
    {
        OnNuevaMIsion.Invoke();
    }
}
