using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreaEscenario : MonoBehaviour {
    
    private const int AIRE = 0;
    private const int TIERRA = 1;
    private const int CESPED_LARGO = 2;
    private const int CESPED = 3;
    private const int AGUA_LARGO = 4;
    private const int AGUA = 5;
    private const int CORY = 6;


    public GameObject Tierra;
    public GameObject Cesped_largo;
    public GameObject Cesped;
    public GameObject Agua_largo;
    public GameObject Agua;
    public GameObject Cory;

    public Camera CamaraPrincipal;

    public PhysicMaterial ReboteMaterial;

    // Use this for initialization
    void Start () {

        LevelContainer lc = LevelContainer.Load();
        /*
         * Get selected Level to Play from previous Scene (Map)
         * For the moment, we save a test number in levelToLoad
         */

        int levelToLoad = 1;
        Level actualLevel = lc.levels[levelToLoad];

        for (int i = 0; i < actualLevel.mapElements.Count; i++)
        {
            for (int j = 0; j < actualLevel.mapElements[i].Count; j++)
            {
                Vector3 posCentral = new Vector3(j, i + 1, 0);

                if (actualLevel.mapElements[i][j] == TIERRA)
                {
                    Instantiate(Tierra, posCentral, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CESPED_LARGO)
                {
                    Instantiate(Cesped_largo, posCentral, Quaternion.Euler(new Vector3(0 , 90, 0)));
                }
                if (actualLevel.mapElements[i][j] == CESPED)
                {
                    if(i != 0 && actualLevel.mapElements[i-1][j] == AIRE)
                    {
                        Instantiate(Cesped, posCentral, Quaternion.Euler(new Vector3(0, 0, 180)));
                    }
                    else
                    {
                        Instantiate(Cesped, posCentral, Quaternion.identity);
                    }
                }
                if (actualLevel.mapElements[i][j] == AGUA_LARGO)
                {
                    Instantiate(Agua_largo, posCentral, Quaternion.Euler(new Vector3(0, 90, 0)));
                }
                if (actualLevel.mapElements[i][j] == AGUA)
                {
                    Instantiate(Agua, posCentral, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CORY)
                {
                    Instantiate(Cory, posCentral, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(posCentral.x + 15, posCentral.y + 10, posCentral.z - 20);
                    Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -12, -2)));
                }
            }
        }
        
	}

}
