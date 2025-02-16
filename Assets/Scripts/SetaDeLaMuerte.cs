using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetaDeLaMuerte : MonoBehaviour, IInteractable
{
    [SerializeField] MisionSO mision;

    [SerializeField] EventManagerSO eventManager;
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {        
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void interactuar(Transform interactor)
    {
        mision.repeticionActual++;

        if (mision.repeticionActual < mision.totalRepeteciones)
        {
            eventManager.ActualizarMision(mision);
        }
        else
        {
            eventManager.TerminarMision(mision);
        }

        Destroy(gameObject);
    }
}
