using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMision : MonoBehaviour
{

    [SerializeField] TMP_Text textoMison;

    Toggle togglerVisual;

    public TMP_Text TextoMison { get => textoMison; set => textoMison = value; }
    public Toggle TogglerVisual { get => togglerVisual; set => togglerVisual = value; }

    private void Awake()
    {
        togglerVisual = GetComponent<Toggle>();
    }

}
