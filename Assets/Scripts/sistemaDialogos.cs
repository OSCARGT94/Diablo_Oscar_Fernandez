using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sistemaDialogos : MonoBehaviour
{
    //Patron Single-ton:
    //1.Sólo existe una única instancia de sistemaDialogos.
    //2.Es accesible DESDE CUALQUIER PUNTO del programa.

    public static sistemaDialogos sistema;
    // Start is called before the first frame update
    void Awake()
    {
        //Si el trono está libre...
        if (sistema == null)
        {
            //Me hago con el trono, y entonces sistemasDialogos SOY YO (this):
            sistema = this;
            //DontDestroyOnLoad(gameObject);

        }
        else
        {
            //Me han quitado el trono, por lo tanto, me mato (soy un falso rey).
            Destroy(this.gameObject);
        }
    }
    public void IniciarDialogo(DialogoSO dialogo)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
