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
        if(Game.getSelectedTool() == "Muelle")
        {
            if (GetComponent<Transform>().position.z == 0)
            {
                foreach (Material m in materiales)
                {
                    m.color = Color.red;
                }
                GetComponent<Renderer>().material.color = Color.red;
            }
        }
        
    }

    void OnMouseDown()
    {
        if (Game.getSelectedTool() == "Muelle")
        {
            creaEscenario.GetComponent<ActualizaEscenario>().SetMouseClick(transform.position);
        }
    }

    void OnMouseExit()
    {
        if (Game.getSelectedTool() != "")
        {
            if (GetComponent<Transform>().position.z == 0)
            {
                foreach (Material m in materiales)
                {
                    m.color = Color.white;
                }
            }
        }
    }
}
