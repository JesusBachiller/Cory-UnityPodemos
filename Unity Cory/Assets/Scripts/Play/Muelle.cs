using UnityEngine;
using System.Collections;

public class Muelle : MonoBehaviour {

    public int index;
    public GameObject creaEscenario;

    public GameObject sueloBlock; // Block of suelo where I am

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0;
                 i < Game.getNumMuelles();
                 i++)
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

        for (int i = Game.getNumMuelles();
                 i < Game.getNumMuelles() + Game.getNumAceleradores();
                 i++)
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

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i++)
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

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                 i++)
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
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState() + Game.getNumPortales();
                 i++)
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
            if (!Game.getMuellePuesto(index))
            {
                sueloBlock.GetComponent<MouseOverSuelo>().setContainTool(true);
                Game.setMuellePuesto(index, true);
                sueloBlock.GetComponent<MouseOverSuelo>().setContainTool(true);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleMuelle();
            }
        }
    }

    void OnMouseDrag()
    {
        if (permitirClick())
        {
            if (Game.getMuellePuesto(index))
            {
                sueloBlock.GetComponent<MouseOverSuelo>().setContainTool(false);
                Game.setMuellePuesto(index, false);
                sueloBlock.GetComponent<MouseOverSuelo>().setContainTool(false);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleMuelle();
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

    public void setSueloBlock(GameObject S)
    {
        if(sueloBlock != null)
        {
            sueloBlock.GetComponent<Renderer>().enabled = true;
        }

        sueloBlock = S;

        sueloBlock.GetComponent<Renderer>().enabled = false;
    }

    public GameObject getSueloBlock()
    {
        return sueloBlock;
    }
}
