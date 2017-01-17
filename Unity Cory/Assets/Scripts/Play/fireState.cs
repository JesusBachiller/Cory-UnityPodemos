using UnityEngine;
using System.Collections;

public class fireState : MonoBehaviour {

    public int index;
    public GameObject creaEscenario;
    
    public GameObject aireBlock; // Block of air where I am

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

        for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonFireStateActivado(i) == true && Game.getFireStatePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonIceStateActivado(i) == true && Game.getIceStatePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
             i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState() + Game.getNumPortales(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonPortalActivado(i) == true && Game.getPortalEntradaPuesto(i) == false)
                {
                    permite = false;
                    break;
                }
                if (Game.getBotonPortalActivado(i) == true && Game.getPortalSalidaPuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }

        if (Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
        }

        return permite;
    }

    void OnMouseUp()
    {
        if (permitirClick())
        {
            if (!Game.getFireStatePuesto(index))
            {
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(true);
                Game.setFireStatePuesto(index, true);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleFireState();
            }
        }
    }

    void OnMouseDrag()
    {
        if (permitirClick())
        {
            if (Game.getFireStatePuesto(index))
            {
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                Game.setFireStatePuesto(index, false);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleFireState();
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

    public void setAireBlock(GameObject a)
    {
        aireBlock = a;
    }

    public GameObject getAireBlock()
    {
        return aireBlock;
    }
}
