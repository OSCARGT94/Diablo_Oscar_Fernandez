using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaPatrulla : MonoBehaviour
{
    [SerializeField]NavMeshAgent m_Agent;

    [SerializeField] Transform ruta;
    List<Vector3> ListadoPuntos = new List<Vector3>();


    int indiceActual=-1;//Marca el punto al cual debo ir.

    Vector3 destinoActual;
    [SerializeField] Enemigo main;

    [SerializeField] float velocidadPatrulla;

    private void Awake()
    {
        main.Patrulla= this;
        //m_Agent = GetComponent<NavMeshAgent>();
        foreach (Transform puntos in ruta)
        {
            //Añado todos los puntos de ruta al listado.
            ListadoPuntos.Add(puntos.position);
        }
    }
    private void OnEnable()
    {
        m_Agent.speed = velocidadPatrulla;
        m_Agent.stoppingDistance = 0;
        //indiceActual = -1;
        StartCoroutine(patrullarYesperar());

    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator patrullarYesperar()
    {
        //por siempre
        while (true)
        {

            calcularDestino();//Tendre que calcular el nuevo destino.
            //Ir a destino.
            m_Agent.SetDestination(destinoActual);
            yield return new WaitUntil( ()=> m_Agent.remainingDistance <= 0);
        }

    }

    private void calcularDestino()
    {
        indiceActual++;
        if (indiceActual >= ListadoPuntos.Count)
        {
            indiceActual = 0;
        }
        //Mi destino es dentro del listado de puntos aquel con el nuevo indice calculado.
        destinoActual = ListadoPuntos[indiceActual];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            main.activarcombate(other.transform);
            StopAllCoroutines();
        }
    }
}
