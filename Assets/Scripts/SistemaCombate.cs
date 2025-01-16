using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class SistemaCombate : MonoBehaviour
{
    [SerializeField] Enemigo main;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float velocidadCombate;
    [SerializeField] float distanciaDeAtaque;
    [SerializeField] float danhoAtaque;
    [SerializeField] Animator animator;
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
        agent.stoppingDistance = distanciaDeAtaque;
    }

    // Update is called once per frame
    void Update()
    {
        //Solo si existe un objetivo y es alcanzable
        if (main.Target  != null && agent.CalculatePath(main.Target.position, new NavMeshPath()))
        {
            //Siempre enfoca al objetivo
            EnfocarObjetico();

            //Perseguir objetivo
            agent.SetDestination(main.Target.position);

            // Cuando este a distancia de atacar.
            if (!agent.pathPending && agent.remainingDistance <= distanciaDeAtaque)
            {
                //agent.isStopped = true;
                //atacar -  ejecutar animacion
                animator.SetBool("Attack", true);
            }

        }
        else
        {
            main.ActivarPatrulla();
        }

    }

    private void EnfocarObjetico()
    {
        Vector3 direcionAtargegt = (main.Target.transform.position - transform.position).normalized;

        direcionAtargegt.y = 0;

        quaternion rotacionAtarget = Quaternion.LookRotation(direcionAtargegt);

        transform.rotation = rotacionAtarget;
    }
    #region Ejecutadps por evento
    void atacar()
    {
        //Hacer daño al target.
        main.Target.GetComponent<Player>().HacerDanho(danhoAtaque);
    }
    void FinAnimacionAtaque()
    {
        animator.SetBool("Attack", false);
    }
    #endregion
}
