using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaMisiones : MonoBehaviour
{
    [SerializeField] EventManagerSO eventManager;
    [SerializeField] ToggleMision[] togglesMision;

    private void OnEnable()
    {
        eventManager.OnNuevaMIsion += EncenderToggleMIsion;
    }

    private void EncenderToggleMIsion(MisionSO mision)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
