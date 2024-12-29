using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField] Transform ruta;
    List<Transform> ListadoPuntos = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform puntos in ruta)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
