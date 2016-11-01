using UnityEngine;
using System.Collections;

public class MouseOverPossibleAcelerador : MonoBehaviour {
    

    public GameObject creaEscenario;
    private GameObject Acelerador;

    private Vector3 home;


    public void findAcelerador()
    {
        GameObject[] Aceleradores = GameObject.FindGameObjectsWithTag("Acelerador");
        foreach (GameObject A in Aceleradores)
        {
            int index = A.GetComponent<Acelerador>().index;
            if (Game.getBotonAceleradorActivado(index) && !Game.getAceleradorPuesto(index))
            {
                Acelerador = A;
                break;
            }
        }
                
    }
    
    void OnMouseEnter()
    {
        Acelerador.transform.position = transform.position;
    }

    
}
