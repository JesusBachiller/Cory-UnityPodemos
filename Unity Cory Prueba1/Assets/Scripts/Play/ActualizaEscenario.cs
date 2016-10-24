using UnityEngine;
using System.Collections;

public class ActualizaEscenario : MonoBehaviour {

    public GameObject Muelle;
    public GameObject PosibleAceleradores;
    public GameObject Acelerador;

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
        Instantiate(Acelerador, new Vector3(-1f,-1f,-1f), Quaternion.identity);
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
        foreach(GameObject A in Aceleradores)
        {
            if(A.GetComponent<Acelerador>().getIndex() == indexButton)
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
                Destroy(suelo);
                break;
            }
        }
    }

    public void DestroyMuelle(int indexButton)
    {
        GameObject[] Muelles = GameObject.FindGameObjectsWithTag("Muelle");
        foreach (GameObject M in Muelles)
        {
            if (M.GetComponent<Muelle>().getIndex() == indexButton)
            {
                Instantiate(GetComponent<CreaEscenario>().Cesped, M.transform.position, Quaternion.identity);
                Destroy(M);
            }
        }
    }
}
