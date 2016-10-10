using UnityEngine;
using System.Collections;

public class CreaEscenario : MonoBehaviour {

    private const int aire = 0;
    private const int PIEDRA = 1;
    private const int SUELO = 2;
    private const int AGUA = 3;
    private const int BOLA = 4;

    private int[,] mapa = {  {  PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA},
                            {   SUELO,  SUELO,  AGUA,   SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  AGUA,   AGUA,   SUELO,  PIEDRA, PIEDRA, SUELO,  SUELO,  SUELO,  SUELO,  SUELO,  PIEDRA},
                            {   aire,   BOLA,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   PIEDRA, PIEDRA, aire,   aire,   aire,   aire,   aire,   SUELO},
                            {   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   PIEDRA, PIEDRA, aire,   aire,   aire,   aire,   aire,   aire},
                            {   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   aire,   SUELO,  SUELO,  aire,   aire,   aire,   aire,   aire,   aire}};

    private int numCol = 26;
    private int numFil = 5;


    public GameObject Suelo;
    public GameObject Piedra;
    public GameObject Agua;

    public GameObject Bola;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < numFil; i++)
        {
            for(int j = 0; j < numCol; j++)
            {
                Vector3 posAtras2 = new Vector3(-2, i, j);
                Vector3 posAtras1 = new Vector3(-1, i, j);
                Vector3 posCentral = new Vector3(0, i+1, j);
                Vector3 posDelante1 = new Vector3(1, i, j);
                Vector3 posDelante2 = new Vector3(2, i, j);

                if (mapa[i,j] == PIEDRA)
                {
                    Instantiate(Piedra, posAtras2, Quaternion.identity);
                    Instantiate(Piedra, posAtras1, Quaternion.identity);
                    Instantiate(Piedra, posCentral, Quaternion.identity);
                    Instantiate(Piedra, posDelante1, Quaternion.identity);
                    Instantiate(Piedra, posDelante2, Quaternion.identity);
                }
                if (mapa[i, j] == AGUA)
                {
                    Instantiate(Agua, posAtras2, Quaternion.identity);
                    Instantiate(Agua, posAtras1, Quaternion.identity);
                    Instantiate(Agua, posCentral, Quaternion.identity);
                    Instantiate(Agua, posDelante1, Quaternion.identity);
                    Instantiate(Agua, posDelante2, Quaternion.identity);
                }
                if (mapa[i, j] == SUELO)
                {
                    Instantiate(Suelo, posAtras2, Quaternion.identity);
                    Instantiate(Suelo, posAtras1, Quaternion.identity);
                    Instantiate(Suelo, posCentral, Quaternion.identity);
                    Instantiate(Suelo, posDelante1, Quaternion.identity);
                    Instantiate(Suelo, posDelante2, Quaternion.identity);
                }
                if (mapa[i, j] == BOLA)
                {
                    Instantiate(Bola, posCentral, Quaternion.identity);

                }
            }
        }
	}

    
}
