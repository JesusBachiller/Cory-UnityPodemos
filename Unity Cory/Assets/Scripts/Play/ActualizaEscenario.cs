using UnityEngine;
using System.Collections;
using System;

public class ActualizaEscenario : MonoBehaviour
{

    public GameObject Muelle;
    public GameObject PosibleAceleradores;
    public GameObject Acelerador;
    public GameObject PlanoSuelo;
    public GameObject FireState;
    public GameObject IceState;
    public GameObject PortalEntrada;
    public GameObject PortalSalida;
    /*
    public GameObject myMuelle;
    public GameObject mySuelo;
    */
    private GameObject[] ArraySuelos;

    public int posMouseClick_x;
    public int posMouseClick_y;



    public void InstanciatePortalEntrada(int indexButton)
    {
        GameObject portalEntradaInstanciado = Instantiate(PortalEntrada, new Vector3(-1f, -1f, -1f), Quaternion.identity) as GameObject;

        Color rgbRandomColor = Color.HSVToRGB(UnityEngine.Random.Range(0f, 1f), 1, 1);
        Color c = new Color(rgbRandomColor.r, rgbRandomColor.g, rgbRandomColor.b,1);

        GameObject aroExterior = portalEntradaInstanciado.transform.FindChild("AroExterior").gameObject;
        foreach (Material m in aroExterior.GetComponentInChildren<Renderer>().materials) {
            m.color = c;
        }
        /*GameObject aroInterior = portalEntradaInstanciado.transform.FindChild("AroInterior").gameObject;
        foreach (Material m in aroInterior.GetComponentInChildren<Renderer>().materials)
        {
            m.color = c;
        }*/

        GameObject[] Portales = GameObject.FindGameObjectsWithTag(PortalEntrada.tag);
        Portales[Portales.Length - 1].GetComponent<PortalEntrada>().setIndex(indexButton);
    }
    public void EnablePossiblePortalEntrada()
    {
        GameObject[] PossiblesPortales = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PPortal in PossiblesPortales)
        {
            PPortal.GetComponent<BoxCollider>().enabled = true;
            PPortal.GetComponent<MouseOverPossibleAcelerador>().findObject(PortalEntrada.tag);
        }

    }
    public void NotEnableDestroyPossiblePortalEntrada()
    {
        GameObject[] PossiblesPortales = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PPortal in PossiblesPortales)
        {
            PPortal.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void InstanciatePortalSalida(int indexButton, Color c)
    {
        GameObject portalSalidaInstanciado = Instantiate(PortalSalida, new Vector3(-1f, -1f, -1f), Quaternion.identity) as GameObject;
        GameObject aroExterior = portalSalidaInstanciado.transform.FindChild("AroExterior").gameObject;
        foreach (Material m in aroExterior.GetComponentInChildren<Renderer>().materials)
        {
            m.color = c;
        }
        /*GameObject aroInterior = portalSalidaInstanciado.transform.FindChild("AroInterior").gameObject;
        foreach (Material m in aroInterior.GetComponentInChildren<Renderer>().materials)
        {
            m.color = c;
        }*/

        GameObject[] Portales = GameObject.FindGameObjectsWithTag(PortalSalida.tag);
        Portales[Portales.Length - 1].GetComponent<PortalSalida>().setIndex(indexButton);
    }
    public void EnablePossiblePortalSalida()
    {
        GameObject[] PossiblesPortales = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PPortal in PossiblesPortales)
        {
            PPortal.GetComponent<BoxCollider>().enabled = true;
            PPortal.GetComponent<MouseOverPossibleAcelerador>().findObject(PortalSalida.tag);
        }

    }
    public void NotEnableDestroyPossiblePortalSalida()
    {
        GameObject[] PossiblesPortales = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PPortal in PossiblesPortales)
        {
            PPortal.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DestroyPortal(int indexButton)
    {
        GameObject[] PortalesEntrada = GameObject.FindGameObjectsWithTag(PortalEntrada.tag);
        GameObject[] PortalesSalida = GameObject.FindGameObjectsWithTag(PortalSalida.tag);
        foreach (GameObject P in PortalesEntrada)
        {
            if (P.GetComponent<PortalEntrada>().getIndex() == indexButton)
            {
                if (P.GetComponent<PortalEntrada>().getAireBlock() != null)
                {
                    P.GetComponent<PortalEntrada>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                }
                Destroy(P);
            }
        }
        foreach (GameObject P in PortalesSalida)
        {
            if (P.GetComponent<PortalSalida>().getIndex() == indexButton)
            {
                if (P.GetComponent<PortalSalida>().getAireBlock() != null)
                {
                    P.GetComponent<PortalSalida>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                }
                Destroy(P);
            }
        }
    }

    public void InstanciateFireState(int indexButton)
    {
        Instantiate(FireState, new Vector3(-1f, -1f, -1f), Quaternion.identity);
        GameObject[] FireStates = GameObject.FindGameObjectsWithTag(FireState.tag);
        FireStates[FireStates.Length - 1].GetComponent<fireState>().setIndex(indexButton);
    }
    public void EnablePossibleFireState()
    {
        GameObject[] PossiblesFireState = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PFS in PossiblesFireState)
        {
            PFS.GetComponent<BoxCollider>().enabled = true;
            PFS.GetComponent<MouseOverPossibleAcelerador>().findObject(FireState.tag);
        }

    }
    public void NotEnableDestroyPossibleFireState()
    {
        GameObject[] PossiblesFireStates = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PFS in PossiblesFireStates)
        {
            PFS.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DestroyFireState(int indexButton)
    {
        GameObject[] FireStates = GameObject.FindGameObjectsWithTag(FireState.tag);
        foreach (GameObject FS in FireStates)
        {
            if (FS.GetComponent<fireState>().getIndex() == indexButton)
            {
                if (FS.GetComponent<fireState>().getAireBlock() != null)
                {
                    FS.GetComponent<fireState>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                }
                Destroy(FS);
            }
        }
    }


    public void InstanciateIceState(int indexButton)
    {
        Instantiate(IceState, new Vector3(-1f, -1f, -1f), Quaternion.identity);
        GameObject[] IceStates = GameObject.FindGameObjectsWithTag(IceState.tag);
        IceStates[IceStates.Length - 1].GetComponent<IceState>().setIndex(indexButton);
    }
    public void EnablePossibleIceState()
    {
        GameObject[] PossiblesIceState = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PIS in PossiblesIceState)
        {
            PIS.GetComponent<BoxCollider>().enabled = true;
            PIS.GetComponent<MouseOverPossibleAcelerador>().findObject(IceState.tag);
        }

    }
    public void NotEnableDestroyPossibleIceState()
    {
        GameObject[] PossiblesIceStates = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PIS in PossiblesIceStates)
        {
            PIS.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DestroyIceState(int indexButton)
    {
        GameObject[] IceStates = GameObject.FindGameObjectsWithTag(IceState.tag);
        foreach (GameObject IS in IceStates)
        {
            if (IS.GetComponent<IceState>().getIndex() == indexButton)
            {
                if (IS.GetComponent<IceState>().getAireBlock() != null)
                {
                    IS.GetComponent<IceState>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                }
                Destroy(IS);
            }
        }
    }

    public void InstanciateAcelerador(int indexButton)
    {
        Instantiate(Acelerador, new Vector3(-1f, -1f, -1f), Quaternion.identity);
        GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag(Acelerador.tag);
        Aceleradores[Aceleradores.Length - 1].GetComponent<Acelerador>().setIndex(indexButton);
    }
    public void EnablePossibleAcelerador()
    {
        GameObject[] PossiblesAceleradores = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PA in PossiblesAceleradores)
        {
            PA.GetComponent<BoxCollider>().enabled = true;
            PA.GetComponent<MouseOverPossibleAcelerador>().findObject(Acelerador.tag);
        }

    }
    public void NotEnableDestroyPossibleAceleradores()
    {
        GameObject[] PossiblesAceleradores = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PA in PossiblesAceleradores)
        {
            PA.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DestroyAcelerador(int indexButton)
    {
        GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag(Acelerador.tag);
        foreach (GameObject A in Aceleradores)
        {
            if (A.GetComponent<Acelerador>().getIndex() == indexButton)
            {
                if(A.GetComponent<Acelerador>().getAireBlock() != null)
                {
                    A.GetComponent<Acelerador>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                }
                Destroy(A);
            }
        }
    }

    public void InstanciateMuelle(int indexButton)
    {
        Instantiate(Muelle, new Vector3(-1f, -1f, -1f), Quaternion.identity);
        GameObject[] muelles = GameObject.FindGameObjectsWithTag(Muelle.tag);
        muelles[muelles.Length - 1].GetComponent<Muelle>().setIndex(indexButton);
    }
    public void EnablePossibleMuelle()
    {
        GameObject[] PossiblesMuelles = GameObject.FindGameObjectsWithTag("Suelo");
        Debug.Log(PossiblesMuelles.Length);
        foreach (GameObject PM in PossiblesMuelles)
        {
            PM.GetComponent<BoxCollider>().enabled = true;
            PM.GetComponent<MouseOverSuelo>().findObject(Muelle.tag);
        }

    }
    public void NotEnableDestroyPossibleMuelle()
    {
        GameObject[] PossiblesMuelles = GameObject.FindGameObjectsWithTag("Suelo");

        foreach (GameObject PM in PossiblesMuelles)
        {
            PM.GetComponent<BoxCollider>().enabled = false;
        }
    }
    public void DestroyMuelle(int indexButton)
    {
        GameObject[] Muelles = GameObject.FindGameObjectsWithTag(Muelle.tag);
        foreach (GameObject M in Muelles)
        {
            if (M.GetComponent<Muelle>().getIndex() == indexButton)
            {
                if (M.GetComponent<Muelle>().getSueloBlock() != null)
                {
                    M.GetComponent<Muelle>().getSueloBlock().GetComponent<MouseOverSuelo>().setContainTool(false);
                }
                Destroy(M);
            }
        }
    }

    /*public void InstanciateMuelle(Vector3 Pos, int index)
    {
        posMouseClick_x = (int)Pos.x;
        posMouseClick_y = (int)Pos.y;

        ArraySuelos = GameObject.FindGameObjectsWithTag("Suelo");

        foreach (GameObject suelo in ArraySuelos)
        {
            if (suelo.transform.position.x == Pos.x && suelo.transform.position.y == Pos.y && suelo.transform.position.z == 0)
            {
                Instantiate(Muelle, suelo.transform.position, Quaternion.identity);
                GameObject[] muelles = GameObject.FindGameObjectsWithTag("Muelle");
                muelles[muelles.Length - 1].GetComponent<Muelle>().setIndex(index);
                //Destroy(suelo);
                suelo.GetComponent<Renderer>().enabled = false;
                break;
            }
        }
        updatePlanosSobreCesped();
    }

    public void DestroyMuelle(int indexButton)
    {
        GameObject[] Muelles = GameObject.FindGameObjectsWithTag("Muelle");
        foreach (GameObject M in Muelles)
        {
            if (M.GetComponent<Muelle>().getIndex() == indexButton)
            {
                GameObject[] suelosCesped = GameObject.FindGameObjectsWithTag("Suelo");
                foreach (GameObject s in suelosCesped)
                {
                    if (s.transform.position.x == M.transform.position.x && s.transform.position.y == M.transform.position.y && M.transform.position.z == 0)
                    {
                        s.GetComponent<Renderer>().enabled = true;
                        break;
                    }
                }
                Destroy(M);
                break;
            }
        }
        updatePlanosSobreCesped();
    }

    public void ChangePosMuelle(int index)
    {
        GameObject[] Muelles = GameObject.FindGameObjectsWithTag("Muelle");
        

        foreach (GameObject M in Muelles)
        {
            if (M.GetComponent<Muelle>().getIndex() == index)
            {
                GameObject[] suelosCesped = GameObject.FindGameObjectsWithTag("Suelo");
                foreach (GameObject s in suelosCesped)
                {
                    if (s.transform.position.x == M.transform.position.x && s.transform.position.y == M.transform.position.y && M.transform.position.z == 0)
                    {
                        myMuelle = M;
                        mySuelo = s;
                        break;
                    }
                }
                break;
            }
        }

    }*/

    public void destroyPlanosSobreCesped()
    {
        GameObject[] planosSobreCesped = GameObject.FindGameObjectsWithTag("PlanoSobreCesped");
        foreach (GameObject p in planosSobreCesped)
        {
            Destroy(p);
        }
    }

    public void updatePlanosSobreCesped()
    {
        destroyPlanosSobreCesped();
        GameObject[] suelosCesped = GameObject.FindGameObjectsWithTag("Suelo");

        int tamanoPlanoSobreCesped = 0;
        float sumaX = 0;
        float xMediaPlanoSobreCesped = 0;
        GameObject planoInstanciado = new GameObject();
        Vector3 positionPlanoSobreCesped = new Vector3();

        for (int i = 0; i < suelosCesped.Length; i++)
        {
            if (tamanoPlanoSobreCesped == 0 && suelosCesped[i].GetComponent<Renderer>().enabled )
            {
                // Creamos una nueva tira (plano sobre cesped)
                Vector3 posicionPlanoLateralIzquierdo = suelosCesped[i].transform.position + new Vector3(-0.51f, 0, 0);
                Instantiate(PlanoSuelo, posicionPlanoLateralIzquierdo, Quaternion.Euler(new Vector3(0, 0, 90)));
                
                if(suelosCesped[i].transform.rotation.z == 0)
                {
                    positionPlanoSobreCesped = suelosCesped[i].transform.position + new Vector3(0, 0.51f, 0);
                    planoInstanciado = Instantiate(PlanoSuelo, positionPlanoSobreCesped, Quaternion.identity) as GameObject;
                }
                else
                {
                    positionPlanoSobreCesped = suelosCesped[i].transform.position + new Vector3(0, -0.51f, 0);
                    planoInstanciado = Instantiate(PlanoSuelo, positionPlanoSobreCesped, Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject;
                }
                
            }
            if (suelosCesped[i].GetComponent<Renderer>().enabled)
            {
                // La tira (plano sobre cesped) continúa
                tamanoPlanoSobreCesped += 1;
                sumaX += suelosCesped[i].transform.position.x;
            }
            if (
                    (i + 1 < suelosCesped.Length && suelosCesped[i].GetComponent<Renderer>().enabled && ((suelosCesped[i + 1].transform.position.x - suelosCesped[i].transform.position.x) > 1) && suelosCesped[i + 1].GetComponent<Renderer>().enabled) ||
                    (i + 1 < suelosCesped.Length && suelosCesped[i].GetComponent<Renderer>().enabled && !suelosCesped[i + 1].GetComponent<Renderer>().enabled) ||
                    (i + 1 < suelosCesped.Length && suelosCesped[i].GetComponent<Renderer>().enabled && suelosCesped[i].transform.position.y != suelosCesped[i + 1].transform.position.y) ||
                    (i + 1 >= suelosCesped.Length && suelosCesped[i].GetComponent<Renderer>().enabled)
                )
            {
                Vector3 posicionPlanoLateralDerecho = suelosCesped[i].transform.position + new Vector3(+0.51f, 0, 0);
                Instantiate(PlanoSuelo, posicionPlanoLateralDerecho, Quaternion.Euler(new Vector3(0, 0, -90)));
                // Se ha acabado una tira (plano sobre cesped)
                xMediaPlanoSobreCesped = sumaX / tamanoPlanoSobreCesped;
                planoInstanciado.transform.position = new Vector3(xMediaPlanoSobreCesped, positionPlanoSobreCesped.y, positionPlanoSobreCesped.z);
                planoInstanciado.transform.localScale = new Vector3(0.1f * tamanoPlanoSobreCesped, 0.1f, 0.1f);

                tamanoPlanoSobreCesped = 0;
                sumaX = 0;
                xMediaPlanoSobreCesped = 0;
                planoInstanciado = new GameObject();
                positionPlanoSobreCesped = new Vector3();                //Debug.Log("Cubo x:" + suelosCesped[i].transform.position.x + " y:" + suelosCesped[i].transform.position.y + "else if");
            }
        }

    }

    public static Color HSVToRGB(float H, float S, float V)
    {
        if (S == 0f)
            return new Color(V, V, V);
        else if (V == 0f)
            return Color.black;
        else
        {
            Color col = Color.black;
            float Hval = H * 6f;
            int sel = Mathf.FloorToInt(Hval);
            float mod = Hval - sel;
            float v1 = V * (1f - S);
            float v2 = V * (1f - S * mod);
            float v3 = V * (1f - S * (1f - mod));
            switch (sel + 1)
            {
                case 0:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 1:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
                case 2:
                    col.r = v2;
                    col.g = V;
                    col.b = v1;
                    break;
                case 3:
                    col.r = v1;
                    col.g = V;
                    col.b = v3;
                    break;
                case 4:
                    col.r = v1;
                    col.g = v2;
                    col.b = V;
                    break;
                case 5:
                    col.r = v3;
                    col.g = v1;
                    col.b = V;
                    break;
                case 6:
                    col.r = V;
                    col.g = v1;
                    col.b = v2;
                    break;
                case 7:
                    col.r = V;
                    col.g = v3;
                    col.b = v1;
                    break;
            }
            col.r = Mathf.Clamp(col.r, 0f, 1f);
            col.g = Mathf.Clamp(col.g, 0f, 1f);
            col.b = Mathf.Clamp(col.b, 0f, 1f);
            return col;
        }
    }
}
