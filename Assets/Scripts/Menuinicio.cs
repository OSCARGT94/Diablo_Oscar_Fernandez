using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); Para cuando tienes varios niveles
        SceneManager.LoadScene(1);
        
    }
    public void inicio()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); Para cuando tienes varios niveles
        SceneManager.LoadScene(0);
        
    }
}
