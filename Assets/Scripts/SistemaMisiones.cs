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
        eventManager.OnActualizarMision += ActualizarTOggleMision;
        eventManager.OnTerminarMision += TermianrToggleMision;

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

    private void ActualizarTOggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TextoMison.text = mision.ordenInicial;
        togglesMision[mision.indiceMision].TextoMison.text += "(" + mision.repeticionActual + "/" + mision.totalRepeteciones + ")";
    }

    private void TermianrToggleMision(MisionSO mision)
    {
        togglesMision[mision.indiceMision].TogglerVisual.isOn = true;
        togglesMision[mision.indiceMision].TextoMison.text = mision.ordenFinal;
    }

}
