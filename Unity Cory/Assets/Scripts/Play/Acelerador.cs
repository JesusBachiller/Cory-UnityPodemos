using UnityEngine;
using System.Collections;

public class Acelerador : MonoBehaviour {

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
                    //Debug.Log(i);
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
            if (Game.getAceleradorPuesto(index))
            {
                Game.setAceleradorPuesto(index, false);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleAcelerador();
                GetComponent<BoxCollider>().size = new Vector3(1f, 1f, 1f);
            }
            else
            {
                Game.setAceleradorPuesto(index, true);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleAceleradores();
                GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
            }
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
