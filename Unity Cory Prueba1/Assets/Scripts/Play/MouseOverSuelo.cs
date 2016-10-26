using UnityEngine;
using System.Collections;

public class MouseOverSuelo : MonoBehaviour {

    private Material[] materiales;
    public GameObject creaEscenario;

    int index;
 
    void Start()
    {
        index = -1;
        materiales = GetComponent<Renderer>().materials;
    }

    private bool permite()
    {
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            if (Game.getBotonMuelleActivado(i) && !Game.getMuellePuesto(i))
            {
                index = i;
                return true;
            }
        }
        index = -1;
        return false;
    }

    void OnMouseEnter()
    {
        if (permite())
        {
            foreach (Material m in materiales)
            {
                m.color = Color.red;
            }
            GetComponent<Renderer>().material.color = Color.red;
        }
        
    }

    void OnMouseDown()
    {
        if (permite())
        {
            creaEscenario.GetComponent<ActualizaEscenario>().InstanciateMuelle(transform.position, index);
            Game.setMuellePuesto(index, true);

            foreach (Material m in materiales)
            {
                m.color = Color.white;
            }
        }
    }

    void OnMouseExit()
    {
        if (permite())
        {
            foreach (Material m in materiales)
            {
                m.color = Color.white;
            }
        }
    }
}
