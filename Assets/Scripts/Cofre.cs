using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cofre : MonoBehaviour
{
    Outline outline;
    [SerializeField] Texture2D iconoCofre;
    [SerializeField] Texture2D iconoOriginal;
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
        Cursor.SetCursor(iconoCofre,Vector2.zero, CursorMode.Auto);
        outline.enabled = true;
    }
    private void OnMouseExit()
    {
        Cursor.SetCursor(iconoOriginal, Vector2.zero, CursorMode.Auto);
        outline.enabled = false;
    }
}
