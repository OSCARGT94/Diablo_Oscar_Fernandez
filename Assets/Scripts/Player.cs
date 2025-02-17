using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    

    public Image barritadeVIda;

    public float vidaActual;

    public float vidaMaxima;

    Camera cam;
    NavMeshAgent agent;
    [SerializeField]float distanciaDeParado;
    float distanciaParadoBase = 0;

    //Almaceno el ultimo transform que clicke con el ratón.
    Transform ultimoClick;
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movimiento();
        }
        ComprobarInteracion();
        barritadeVIda.fillAmount = vidaActual / vidaMaxima;

        

    }
      

    private void Movimiento()
    {
        //Si clicko con el mouse iz.
        if (Input.GetMouseButtonDown(0))
        {

            //Creo un rayo desde la camara a la posicion del ratón.
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //Si impacta en algo...
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //Le decimos al agente (nosotros) que tiene como destino el punto de impacto.
                agent.SetDestination(hitInfo.point);

                //Actualizo el últimohit cono el trasnfomr que acabo de clickar.
                ultimoClick = hitInfo.transform;

            }

        }
    }
    private void ComprobarInteracion()
    {
        if (ultimoClick != null && ultimoClick.TryGetComponent( out IInteractable interactable))
        {
            //Actualizo distancia de parada paa nop comerme al npc.
            agent.stoppingDistance = distanciaDeParado;

            //Saber si hemos llegado.
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                interactable.interactuar(transform);

                //Me olvido de cual fue el ultimo click, porque solo quiero interactuar una vez.
                ultimoClick = null;

            }

        }
        //si no es un NPc y es suelo...
        else if (ultimoClick)
        {
            //Reseteo el stopping distance.
            agent.stoppingDistance = distanciaParadoBase;
        }
    }

    public void HacerDanho(float danhoAtaque)
    {
        Debug.Log("Me hacen pupa" + danhoAtaque);
        vidaActual -= danhoAtaque;
    }
    
}
