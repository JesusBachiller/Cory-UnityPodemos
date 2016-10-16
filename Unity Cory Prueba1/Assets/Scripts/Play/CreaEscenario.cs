using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CreaEscenario : MonoBehaviour {

    private const int AIRE = 0;
    private const int TIERRA = 1;
    private const int CESPED = 2;
    private const int AGUA = 3;
    private const int PINCHO = 4;
    private const int PLATAFORMA_ROTATORIA = 5;
    private const int LEVEL_END = 8;
    private const int CORY = 9;


    public GameObject Tierra;
    public GameObject Cesped;
    public GameObject Agua;
    public GameObject Pincho;
    public GameObject PlataformaRotatoria;
    public GameObject Cory;
    public GameObject LevelEnd;

    public Camera CamaraPrincipal;

    public PhysicMaterial ReboteMaterial;

    // Use this for initialization
    void Start () {
        /*
         * Get selected Level to Play from previous Scene (Map)
         * For the moment, we save a test number in levelToLoad
         */

        Level actualLevel = Game.getCurrentLevel();

        for (int i = 0; i < actualLevel.mapElements.Count; i++)
        {
            for (int j = 0; j < actualLevel.mapElements[i].Count; j++)
            {
                Vector3 position = new Vector3(j, i + 1, 0);

                if (actualLevel.mapElements[i][j] == TIERRA)
                {
                    Instantiate(Tierra, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CESPED)
                {
                    if(i != 0 && actualLevel.mapElements[i-1][j] == AIRE)
                    {
                        Instantiate(Cesped, position, Quaternion.Euler(new Vector3(0, 0, 180)));
                    }
                    else
                    {
                        Instantiate(Cesped, position, Quaternion.identity);
                    }
                }
                if (actualLevel.mapElements[i][j] == AGUA)
                {
                    Instantiate(Agua, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == PINCHO)
                {
                    Instantiate(Pincho, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == PLATAFORMA_ROTATORIA)
                {
                    Instantiate(PlataformaRotatoria, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == LEVEL_END)
                {
                    Instantiate(LevelEnd, new Vector3(position.x, position.y+2, position.z), Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CORY)
                {
                    Instantiate(Cory, position, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(position.x + 15, position.y + 10, position.z - 20);
                    Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -12, -2)));
                }
            }
        }
        
	}
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Game.resetAllValues();
            SceneManager.LoadScene("WorldMap");
        }



    }
}
