using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMinimapa : MonoBehaviour
{
    [SerializeField] Player player;
    Vector3 distanciaPlayer;
    // Start is called before the first frame update
    void Start()
    {
        //Calculo la distancia inicial enre e player y yo.
        distanciaPlayer = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Me posiciono.
        transform.position = player.transform.position + distanciaPlayer;
    }
}
