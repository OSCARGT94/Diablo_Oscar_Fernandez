using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    [SerializeField] float duracionRotacion;
    public void Interactuar(Transform interactuador)
    {

        Debug.Log("Hola viajero.");

        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
