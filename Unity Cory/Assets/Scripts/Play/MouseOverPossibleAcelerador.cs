using UnityEngine;
using System.Collections;

public class MouseOverPossibleAcelerador : MonoBehaviour
{

    public bool containTool; //Is there a tool inside of me?

    public GameObject creaEscenario;
    private GameObject Acelerador;
    private GameObject FireState;

    private Vector3 home;


    public void findObject(string s)
    {
        Acelerador = null;
        FireState = null;

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