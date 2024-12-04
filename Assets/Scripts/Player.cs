using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
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

            }

        }
    }
}
