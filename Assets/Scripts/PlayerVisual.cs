using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Velocity", agent.velocity.magnitude / agent.speed);
    }
}
