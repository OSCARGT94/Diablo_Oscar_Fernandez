using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] ToggleMision[] togglesMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMision += EncenderToggleMision;
    }

    private void EncenderToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMison.text = mision.ordenInicial;

        if (mision.tieneRepeticion)
        {
            togglesMision[mision.indiceMision].TextoMison.text += "(" + mision.repeticionActual + "/" + mision.totalRepeteciones + ")";
        }

        togglesMision[mision.indiceMision].gameObject.SetActive(true);
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
