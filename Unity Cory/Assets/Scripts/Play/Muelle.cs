using UnityEngine;
using System.Collections;

public class Muelle : MonoBehaviour {

    public int index;
    public GameObject creaEscenario;

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }
        if (permite)
        {
            for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
            {
                if (i != index)
                {
                    Debug.Log(i);
                    if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }
        }
        return permite;
    }

    void OnMouseDown()
    {
        if (permitirClick())
        {
            creaEscenario.GetComponent<ActualizaEscenario>().DestroyMuelle(index);
            Game.setMuellePuesto(index, false);
        }
    }

    public void setIndex(int i)
    {
        index = i;
    }

    public int getIndex()
    {
        return index;
    }
}
