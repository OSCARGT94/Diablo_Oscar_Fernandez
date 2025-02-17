using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Player player;
    int golpeadoactual;
     Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        golpeadoactual = 0;

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
        
        if (player.golpeado > golpeadoactual && player.vidaActual>0)
        {
            
            anim.SetTrigger("Golpeado");

            golpeadoactual++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Atacar");
        }


    }
    public void CambioEscena()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void IniciarGolpe()
    {
        player.GolpeadorTriguer.SetActive(true);
    }
    public void AcabarGolpe()
    {
        player.GolpeadorTriguer.SetActive(false);
    }
}
