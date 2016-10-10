﻿using UnityEngine;
using System.Collections;

public class CreaEscenario : MonoBehaviour {

    public GameObject Suelo;
    public GameObject Piedra;
    public GameObject Agua;
    public GameObject Bola;
    public Camera CamaraPrincipal;
    private const int AIRE = 0;
    private const int PIEDRA = 1;
    private const int CESPED = 2;
    private const int AGUA = 3;
    private const int BOLA = 4;

    private int[,] mapa = {
        { PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA},
        { CESPED, CESPED, AGUA, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, AGUA, AGUA, CESPED, PIEDRA, PIEDRA, CESPED, CESPED, CESPED, CESPED, CESPED, PIEDRA},
        { AIRE, BOLA, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, PIEDRA, PIEDRA, AIRE, AIRE, AIRE, AIRE, AIRE, CESPED},
        { AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, PIEDRA, PIEDRA, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE},
        { AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, CESPED, CESPED, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE}
    };
    // Use this for initialization
    void Start()
    {

        /*WorldMap worldMap = new WorldMap();
        Status status = new Status();
        Stadium actualStadium = worldMap.getStadium(status.getCurrentStadium());
        Level actualLevel = actualStadium.getLevel(status.getCurrentLevel());
        showLevel(actualLevel.getMapElements());*/
        showLevel(mapa); 
    }

    // Update is called once per frame
    void Update()
    {

    }



    void showLevel(int[,] mapElements)
    {

        Debug.Log(mapElements.Rank);
        int numRows = mapElements.Rank;
        for (int i = 0; i < numRows; i++)
        {
            int numCols = mapElements.GetLength(i);
            Debug.Log(mapElements.GetLength(i));
            for (int j = 0; j < numCols; j++)
            {
                Vector3 posCentral = new Vector3(j, i + 1, 0);

                if (mapa[i, j] == PIEDRA)
                {
                    Instantiate(Piedra, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == AGUA)
                {
                    Instantiate(Agua, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == CESPED)
                {
                    Instantiate(Suelo, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == BOLA)
                {
                    Instantiate(Bola, posCentral, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(posCentral.x + 15, posCentral.y + 10, posCentral.z - 25);
                    Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -20, -2)));
                }
            }
        }
    }

    /*private const int AIRE = 0;
    private const int PIEDRA = 1;
    private const int CESPED = 2;
    private const int AGUA = 3;
    private const int BOLA = 4;

    private int[,] mapa = {
        { PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA, PIEDRA},
        { CESPED, CESPED, AGUA, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, CESPED, AGUA, AGUA, CESPED, PIEDRA, PIEDRA, CESPED, CESPED, CESPED, CESPED, CESPED, PIEDRA},
        { AIRE, BOLA, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, PIEDRA, PIEDRA, AIRE, AIRE, AIRE, AIRE, AIRE, CESPED},
        { AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, PIEDRA, PIEDRA, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE},
        { AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE, CESPED, CESPED, AIRE, AIRE, AIRE, AIRE, AIRE, AIRE}
    };

    private int numCol = 26;
    private int numFil = 5;



    // Use this for initialization
    void Start () {
        
        for (int i = 0; i < numFil; i++)
        {
            for(int j = 0; j < numCol; j++)
            {
                Vector3 posCentral = new Vector3(j, i+1, 0);
                
                if (mapa[i,j] == PIEDRA)
                {
                    Instantiate(Piedra, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == AGUA)
                {
                    Instantiate(Agua, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == CESPED)
                {
                    Instantiate(Suelo, posCentral, Quaternion.identity);
                }
                if (mapa[i, j] == BOLA)
                {
                    Instantiate(Bola, posCentral, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(posCentral.x + 15, posCentral.y + 10, posCentral.z -25);
                    Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -20, -2)));
                }
            }
        }
	}*/

}
