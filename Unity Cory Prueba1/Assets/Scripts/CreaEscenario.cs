using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreaEscenario : MonoBehaviour {

    private const int AIRE = 0;
    private const int PIEDRA = 1;
    private const int CESPED = 2;
    private const int AGUA = 3;
    private const int BOLA = 4;

    public GameObject Suelo;
    public GameObject Piedra;
    public GameObject Agua;
    public GameObject Bola;
    public Camera CamaraPrincipal;

    // Use this for initialization
    void Start () {

        LevelContainer lc = LevelContainer.Load();
        /*
         * Get selected Level to Play from previous Scene (Map)
         * For the moment, we save a test number in levelToLoad
         */

        int levelToLoad = 0;
        Level actualLevel = lc.levels[levelToLoad];

        for (int i = 0; i < actualLevel.mapElements.Count; i++)
        {
            for (int j = 0; j < actualLevel.mapElements[i].Count; j++)
            {
                Vector3 posCentral = new Vector3(j, i + 1, 0);

                if (actualLevel.mapElements[i][j] == PIEDRA)
                {
                    Instantiate(Piedra, posCentral, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == AGUA)
                {
                    Instantiate(Agua, posCentral, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CESPED)
                {
                    Instantiate(Suelo, posCentral, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == BOLA)
                {
                    Instantiate(Bola, posCentral, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(posCentral.x + 15, posCentral.y + 10, posCentral.z - 20);
                    Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -12, -2)));
                }
            }
        }
        
	}

}
