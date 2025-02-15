using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour, IInteractable
{
    [SerializeField] float duracionRotacion;
    [SerializeField] DialogoSO miDialogo;

    

    public void interactuar(Transform interactuador)
    {

        Debug.Log("Hola viajero.");
        //Poca a poco voy rotando hacia el interactuador (el player) y CUANDO TERMINE de rotarme...se inicia la interacción.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete (IniciarInteraccion);
    }
    void IniciarInteraccion()
    {
        sistemaDialogos.sistema.IniciarDialogo(miDialogo);
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
