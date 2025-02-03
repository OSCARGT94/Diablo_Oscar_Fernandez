using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walldetector : MonoBehaviour

     
{

    [SerializeField] float changeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color transparente = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 0f);
            materialPared.DOColor(transparente, changeTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            Material materialPared = other.GetComponent<MeshRenderer>().material;
            Color opaco = new Color(materialPared.color.r, materialPared.color.g, materialPared.color.b, 1f);
            materialPared.DOColor(opaco, changeTime);
        }
    }
}
