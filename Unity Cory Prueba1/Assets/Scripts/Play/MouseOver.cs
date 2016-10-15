using UnityEngine;
using System.Collections;

public class MouseOver : MonoBehaviour {

    private Material[] materiales;
    
    private bool clickOK;
    public GameObject creaEscenario;
 
    void Start()
    {
        materiales = GetComponent<Renderer>().materials;

        clickOK = false;
    }

    void OnMouseEnter()
    {
        if (GetComponent<Transform>().position.z == 0)
        {
            foreach(Material m in materiales)
            {
                m.color = Color.red;
            }

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
        if (GetComponent<Transform>().position.z == 0)
        {
            foreach (Material m in materiales)
            {
                m.color = Color.white;
            }
            //GetComponent<Renderer>().material.color = colorInicial;
        }
    }
}
