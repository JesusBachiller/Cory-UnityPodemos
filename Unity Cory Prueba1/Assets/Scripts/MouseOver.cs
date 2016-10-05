using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

    private Color colorInicial;
    private bool clickOK;
    public GameObject creaEscenario;
 
    void Start()
    {
        colorInicial = GetComponent<Renderer>().material.color;

        clickOK = false;
    }

    void OnMouseEnter()
    {
        if (GetComponent<Transform>().position.x == 0)
        {
            GetComponent<Renderer>().material.color = Color.red;
            
            //creaEscenario.SetMouseClick(transform.position);
            
        }
        
    }

    void OnMouseDown()
    {
        creaEscenario.GetComponent<ActualizaEscenario>().SetMouseClick(transform.position);
            
    }

    void OnMouseExit()
    {
        if (GetComponent<Transform>().position.x == 0)
        {
            GetComponent<Renderer>().material.color = colorInicial;
        }
    }
}
