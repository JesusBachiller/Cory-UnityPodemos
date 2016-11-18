﻿using UnityEngine;
using System.Collections;

public class PortalSalida : MonoBehaviour {

    private GameObject cory;
    public int index;
    public GameObject creaEscenario;

    public GameObject aireBlock; // Block of air where I am


    // Use this for initialization
    void Start ()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(cory != null) {
            this.transform.LookAt(cory.transform);
        }
    }


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
                    if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }
            if (permite)
            {
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
                if (permite)
                {
                    for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumPortales(); i++)
                    {
                        if (i != index)
                        {
                            if (Game.getBotonPortalActivado(i) == true && (Game.getPortalEntradaPuesto(i) == false || Game.getPortalSalidaPuesto(i) == false))
                            {
                                permite = false;
                                break;
                            }
                        }
                    }
                }
            }

        }
        if (Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
        }

        return permite;
    }

    void OnMouseDown()
    {
        if (permitirClick())
        {
            if (Game.getPortalSalidaPuesto(index))
            {
                Game.setPortalSalidaPuesto(index, false);
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(true);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalSalida();
            }
            else
            {
                Game.setPortalSalidaPuesto(index, true);
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossiblePortalSalida();
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
}