using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Player player;
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

        if (player.vidaActual <= 0)
        {
            anim.SetBool("Muerte", true);
        }
    }
    public void CambioEscena()
    {
        SceneManager.LoadScene("GameOver");
    }
}
