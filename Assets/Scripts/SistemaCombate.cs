using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] Enemigo main;
    [SerializeField] NavMeshAgent agent;

    [SerializeField] float velocidadCombate;
    private void Awake()
    {
        main.Combate = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        //se ejecuta cuando se activa el script
        agent.speed = velocidadCombate;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(main.Target.position);
    }
}
