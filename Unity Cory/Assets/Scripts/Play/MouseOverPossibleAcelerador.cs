using UnityEngine;
using System.Collections;

public class MouseOverPossibleAcelerador : MonoBehaviour
{

    private bool containTool; //Is there a tool inside of me?

    public GameObject creaEscenario;
    private GameObject Acelerador;
    private GameObject FireState;
    private GameObject IceState;
    private GameObject PortalEntrada;
    private GameObject PortalSalida;

    private Vector3 home;


    public void findObject(string s)
    {
        Acelerador = null;
        FireState = null;
        IceState = null;
        PortalEntrada = null;
        PortalSalida = null;

        if (s == "Acelerador")
        {
            GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject A in Aceleradores)
            {
                int index = A.GetComponent<Acelerador>().index;
                if (Game.getBotonAceleradorActivado(index) && !Game.getAceleradorPuesto(index))
                {
                    Acelerador = A;

                    break;
                }
            }
            return;
        }

        if (s == "FireState")
        {
            GameObject[] FireStates = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject FS in FireStates)
            {
                int index = FS.GetComponent<fireState>().index;
                if (Game.getBotonFireStateActivado(index) && !Game.getFireStatePuesto(index))
                {
                    FireState = FS;

                    break;
                }
            }
            return;
        }

        if (s == "IceState")
        {
            GameObject[] IceStates = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject IS in IceStates)
            {
                int index = IS.GetComponent<IceState>().index;
                if (Game.getBotonIceStateActivado(index) && !Game.getIceStatePuesto(index))
                {
                    IceState = IS;

                    break;
                }
            }
            return;
        }

        if (s == "PortalEntrada")
        {
            GameObject[] Portales = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject P in Portales)
            {
                int index = P.GetComponent<PortalEntrada>().index;
                if (Game.getBotonPortalActivado(index) && !Game.getPortalEntradaPuesto(index))
                {
                    PortalEntrada = P;
                    break;
                }
            }
            return;
        }

        if (s == "PortalSalida")
        {
            GameObject[] Portales = GameObject.FindGameObjectsWithTag(s);
            foreach (GameObject P in Portales)
            {
                int index = P.GetComponent<PortalSalida>().index;
                if (Game.getBotonPortalActivado(index) && !Game.getPortalSalidaPuesto(index))
                {
                    PortalSalida = P;
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
            if (Acelerador != null)
            {
                Acelerador.transform.position = transform.position;
                Acelerador.GetComponent<Acelerador>().setAireBlock(this.gameObject);
            }
            else
            {
                if (FireState != null)
                {
                    FireState.transform.position = transform.position;
                    FireState.GetComponent<fireState>().setAireBlock(this.gameObject);
                }
                else
                {
                    if(IceState != null)
                    {
                        IceState.transform.position = transform.position;
                        IceState.GetComponent<IceState>().setAireBlock(this.gameObject);

                    }
                    else
                    {
                        if (PortalEntrada != null)
                        {
                            PortalEntrada.transform.position = transform.position;
                            PortalEntrada.GetComponent<PortalEntrada>().setAireBlock(this.gameObject);
                        }
                        else
                        {
                            if (PortalSalida != null)
                            {
                                PortalSalida.transform.position = transform.position;
                                PortalSalida.GetComponent<PortalSalida>().setAireBlock(this.gameObject);
                            }
                        }
                    }
                    
                }
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