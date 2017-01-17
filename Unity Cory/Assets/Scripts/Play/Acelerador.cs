using UnityEngine;
using System.Collections;

public class Acelerador : MonoBehaviour {

    public int index;
    public GameObject creaEscenario;

    public GameObject aireBlock; // Block of air where I am

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
            if (!Game.getAceleradorPuesto(index))
            {
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(true);
                Game.setAceleradorPuesto(index, true);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossibleAceleradores();
                GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }

    void OnMouseDrag()
    {
        if (permitirClick())
        {
            if (Game.getAceleradorPuesto(index))
            {
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                Game.setAceleradorPuesto(index, false);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossibleAcelerador();
                GetComponent<BoxCollider>().size = new Vector3(0.5f, 0.5f, 1.1f);
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

    public void setAireBlock(GameObject A)
    {
        aireBlock = A;
    }

    public GameObject getAireBlock()
    {
        return aireBlock;
    }
}
