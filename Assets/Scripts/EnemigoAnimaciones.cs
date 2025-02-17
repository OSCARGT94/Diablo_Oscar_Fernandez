using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoAnimaciones : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Enemigo enemigo;
    Animator anim;
    int golpeadoactual;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        golpeadoactual =0;
    }

    // Update is called once per frame
    void Update()
    {
        //actualizo el parametro velovidad en funcion de la velocidad del agente.
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);

        if ( enemigo.vidaActual <= 0)
        {
            anim.SetBool("Morir", true);
        }
        if (enemigo.golpeadoEnemigo > golpeadoactual && enemigo.vidaActual > 0)
        {

            anim.SetTrigger("Golpeado");

            golpeadoactual++;
        }
        
    }
    public void LLamarDestruccion()
    {
        enemigo.destruir();
    }
}
