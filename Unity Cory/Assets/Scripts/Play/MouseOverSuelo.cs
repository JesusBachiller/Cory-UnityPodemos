using UnityEngine;
using System.Collections;

public class MouseOverSuelo : MonoBehaviour {

    private bool containTool; //Is there a tool inside of me?

    public GameObject creaEscenario;
    private GameObject Muelle;

    private Material[] materiales;
 
    public void findObject(string s)
    {
        Muelle = null;

        if (s == "Muelle")
        {
            GameObject[] Muelles = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject M in Muelles)
            {
                int index = M.GetComponent<Muelle>().index;
                if (Game.getBotonMuelleActivado(index) && !Game.getMuellePuesto(index))
                {
                    Muelle = M;

                    break;
                }
            }
            return;
        }
    }

    void OnMouseEnter()
    {
        if (!containTool)
        {
            if (Muelle != null)
            {
                Muelle.transform.position = transform.position;
                Muelle.GetComponent<Muelle>().setSueloBlock(this.gameObject);

                GetComponent<Renderer>().enabled = false;
            }
        }
    }

    public void setContainTool(bool b)
    {
        containTool = b;
    }
    public bool getContainTool()
    {
        return containTool;
    }
    
}
