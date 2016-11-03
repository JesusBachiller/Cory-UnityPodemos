using UnityEngine;
using System.Collections;

public class ActualizaEscenario : MonoBehaviour
{

    public GameObject Muelle;
    public GameObject PosibleAceleradores;
    public GameObject Acelerador;
    public GameObject PlanoSuelo;

    private GameObject[] ArraySuelos;

    public int posMouseClick_x;
    public int posMouseClick_y;



    public void EnablePossibleAcelerador()
    {
        GameObject[] PossiblesAceleradores = GameObject.FindGameObjectsWithTag("Aire");

        foreach (GameObject PA in PossiblesAceleradores)
        {
            PA.GetComponent<BoxCollider>().enabled = true;
            PA.GetComponent<MouseOverPossibleAcelerador>().findAcelerador();
        }

    }

    public void InstanciateAcelerador(int indexButton)
    {
        Instantiate(Acelerador, new Vector3(-1f, -1f, -1f), Quaternion.identity);
        GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag("Acelerador");
        Aceleradores[Aceleradores.Length - 1].GetComponent<Acelerador>().setIndex(indexButton);

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
        GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag("Acelerador");
        foreach (GameObject A in Aceleradores)
        {
            if (A.GetComponent<Acelerador>().getIndex() == indexButton)
            {
                Destroy(A);
            }
        }
    }

    public void InstanciateMuelle(Vector3 Pos, int index)
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
                    }
                }
                //Instantiate(GetComponent<CreaEscenario>().Cesped, M.transform.position, Quaternion.identity);
                Destroy(M);
            }
        }
        updatePlanosSobreCesped();
    }

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
                positionPlanoSobreCesped = suelosCesped[i].transform.position + new Vector3(0, 0.51f, 0);
                planoInstanciado = Instantiate(PlanoSuelo, positionPlanoSobreCesped, Quaternion.identity) as GameObject;
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
}
