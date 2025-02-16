using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Mision")]

public class MisionSO : ScriptableObject
{
    public string ordenInicial;
    public string ordenFinal;
    public bool tieneRepeticion;
    public int totalRepeteciones;
    public int indiceMision;

    [NonSerialized]
    public int repeticionActual;
}
