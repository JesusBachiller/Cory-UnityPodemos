using UnityEngine;
using System.Collections;

public class ActualizaEscenario : MonoBehaviour {

    public GameObject Muelle;

    public int posMouseClick_x;
    public int posMouseClick_y;
    
    private GameObject[] ArraySuelos;
    

    public void SetMouseClick(Vector3 Pos)
    {
        posMouseClick_x = (int)Pos.x;
        posMouseClick_y = (int)Pos.y;

        //Debug.Log(Pos);
        ArraySuelos = GameObject.FindGameObjectsWithTag("Suelo");

        foreach (GameObject suelo in ArraySuelos)
        {
            if (suelo.transform.position.x == Pos.x && suelo.transform.position.y == Pos.y && suelo.transform.position.z == 0)
            {
                Instantiate(Muelle, suelo.transform.position, Quaternion.identity);
                Destroy(suelo);
                break;
            }
        }
    }
}
