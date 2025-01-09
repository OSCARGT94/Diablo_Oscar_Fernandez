using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    SistemaPatrulla patrulla;
    SistemaCombate combate;
    Transform target;

    

    public SistemaPatrulla Patrulla { get => patrulla; set => patrulla = value; }
    public SistemaCombate Combate { get => combate; set => combate = value; }
    public Transform Target { get => target; set => target = value; }

    internal void activarcombate(Transform target)
    {
        combate.enabled = true;
        patrulla.enabled = false;
        this.target = target;
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
