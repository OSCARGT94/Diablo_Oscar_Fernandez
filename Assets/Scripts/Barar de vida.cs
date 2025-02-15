using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barardevida : MonoBehaviour
{
    public Image barritadeVIda;

    public float vidaActual;

    public float vidaMaxima;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barritadeVIda.fillAmount = vidaActual/vidaMaxima;
    }
}
