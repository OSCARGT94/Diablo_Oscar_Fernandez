using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    SistemaPatrulla patrulla;
    SistemaCombate combate;
    Transform target;

    public Image barritadeVIda;

    public float vidaActual;

    public float vidaMaxima;

    public int golpeadoEnemigo;

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Target { get => target; set => target = value; }
    
    
    internal void activarcombate(Transform target)
    {
        combate.enabled = true;
        patrulla.enabled = false;
        this.target = target;
    }

    internal void ActivarPatrulla()
    {
        
        combate.enabled = false;
        patrulla.enabled = true;

    }

    // Start is called before the first frame update
    void Start()
    {
        golpeadoEnemigo = 0;
        patrulla.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        barritadeVIda.fillAmount = vidaActual / vidaMaxima;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolpeEspada"))
        {
            vidaActual -= 10;
            golpeadoEnemigo++;
        }
    }

}
