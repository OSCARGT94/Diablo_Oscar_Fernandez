using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour, IInteractable
{

    [SerializeField] EventManagerSO evntmanager;

    [SerializeField] MisionSO miMision;

    [SerializeField] float duracionRotacion;
    [SerializeField] DialogoSO miDialogo1;
    [SerializeField] DialogoSO miDialogo2;

    DialogoSO DialogoActual;
    private void OnEnable()
    {
        evntmanager.OnTerminarMision += CambiarDialogo;
    }
    private void OnDisable()
    {
        evntmanager.OnTerminarMision -= CambiarDialogo;
    }

    private void CambiarDialogo(MisionSO misionTerminada)
    {
        if (miMision == misionTerminada)
        {
            DialogoActual = miDialogo2;
        }
    }

    private void Awake()
    {
        DialogoActual = miDialogo1;
    }

    public void interactuar(Transform interactuador)
    {

        Debug.Log("Hola viajero.");
        //Poca a poco voy rotando hacia el interactuador (el player) y CUANDO TERMINE de rotarme...se inicia la interacción.
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete (IniciarInteraccion);
    }
    void IniciarInteraccion()
    {
        sistemaDialogos.sistema.IniciarDialogo(DialogoActual);
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
