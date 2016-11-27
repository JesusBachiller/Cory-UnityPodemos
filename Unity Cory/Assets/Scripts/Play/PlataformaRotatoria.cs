using UnityEngine;
using System.Collections;

public class PlataformaRotatoria : MonoBehaviour {
    
    public int index;

    public Vector3 poss_init;
    public Vector3 poss_end;

    public Vector3 v_Init_End;
    
    public float rad;
    public float degrees;

    // Use this for initialization
    void Start () {

        poss_init = Vector3.zero;
        poss_end = Vector3.zero;

        v_Init_End = Vector3.zero;

        rad = 0f;
        degrees = 0f;
        
    }

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
            }
        }

        if (Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
        }

        return permite;
    }

    public void rotatePlataform()
    {
        if (permitirClick())
        {
            if (poss_init != Vector3.zero && poss_end != Vector3.zero)
            {
                v_Init_End = new Vector3(poss_end.x - poss_init.x, poss_end.y - poss_init.y, poss_end.z - poss_init.z);
                if (v_Init_End.y != 0)
                {
                    rad = Mathf.Atan(v_Init_End.x / v_Init_End.y);
                    //Debug.Log("Radianes: " + rad);
                    degrees = rad * 180f / Mathf.PI;
                    //Debug.Log("grados: " + degrees);

                    transform.eulerAngles = new Vector3(0f, 0f, -degrees);

                    //Debug.Log(transform.eulerAngles);
                }

            }
        }
        
    }
}
