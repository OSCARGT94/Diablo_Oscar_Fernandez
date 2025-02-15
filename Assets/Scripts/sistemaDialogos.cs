using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sistemaDialogos : MonoBehaviour
{
    //Patron Single-ton:
    //1.Sólo existe una única instancia de sistemaDialogos.
    //2.Es accesible DESDE CUALQUIER PUNTO del programa.
    [SerializeField] EventManagerSO eventManager;

    [SerializeField] GameObject marcoDialogo;

    [SerializeField] TMP_Text textoDialogo;

    bool escribiendo;
    int indiciFraseActual = 0;

    DialogoSO dialogoActual; //Cual es el dialogo con el que estamos actuando.

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

    // Update is called once per frame
    void Update()
    {

    }
    public void IniciarDialogo(DialogoSO dialogo)
    {

        Time.timeScale = 0;

        marcoDialogo.SetActive(true);
        dialogoActual = dialogo;

        StartCoroutine(EscribirFrase());

    }
    IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = string.Empty;
        //Desmenuzo la frase actual por caracteres actual.
        char[] frasesEnLetras = dialogoActual.frases[indiciFraseActual].ToCharArray();

        foreach (char letra in frasesEnLetras)
        {
            //1-Incluir la letra en el texto.
            //2-Esperar.
            textoDialogo.text += letra;

            // WaitForSecondsRealtime no se para si se congela el tiempo como el WaitForSeconds normal.
            yield return new WaitForSecondsRealtime (dialogoActual.tiempoEntreLetras);
        }
        escribiendo = false;
    }
    void CompletarFrase()
    {
        //Si me piden completarla la pongo entera de golpe.
        textoDialogo.text = dialogoActual.frases[indiciFraseActual];
        //Y paro las demas corrutinas.
        StopAllCoroutines();

        escribiendo = false;
    }
    public void SiguienteFrase()
    {
        if (!escribiendo)//Si no estoy...
        {

            //En public para hacerl el click
            indiciFraseActual++;
            //Si aun quedan por sacar...
            if (indiciFraseActual < dialogoActual.frases.Length)
            {
                //la escribo.
                StartCoroutine(EscribirFrase());

            }
            else
            {
                FinalizarDialogo();
            }

        }else
        {
            CompletarFrase();
        }
    }
    void FinalizarDialogo()
    {
        marcoDialogo.SetActive(false); //Cerramos el marco de dialogo actual.
        indiciFraseActual = 0; //Para volver a empezar desde cero la proxima vez.
        escribiendo = false;
        if (dialogoActual.tieneMision)
        {
            eventManager.NuevaMIsion();
        }

        dialogoActual = null; //Ya no tengo dialogo que escribir.

        Time.timeScale = 1;
    }
}
