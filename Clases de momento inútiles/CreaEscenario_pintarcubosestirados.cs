using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreaEscenario : MonoBehaviour
{

    private const int AIRE = 0;
    private const int TIERRA = 1;
    private const int CESPED = 2;
    private const int AGUA = 3;
    private const int PINCHO = 4;
    private const int PLATAFORMA_ROTATORIA = 5;
    private const int LEVEL_END = 8;
    private const int CORY = 9;


    public GameObject Aire;
    public GameObject Tierra;
    public GameObject Cesped;
    public GameObject PlanoSuelo;
    public GameObject Agua;
    public GameObject Pincho;
    public GameObject PlataformaRotatoria;
    public GameObject Cory;
    public GameObject LevelEnd;

    public GameObject CanvasButtons;
    public GameObject ButtonMuelle;
    public GameObject ButtonAcelerador;

    public Camera CamaraPrincipal;
    public PhysicMaterial ReboteMaterial;

    Level actualLevel;

    // Use this for initialization
    void Start()
    {

        /*
            Creation button and positioning at screen (top right)
        */
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            Instantiate(ButtonMuelle, Vector3.zero, Quaternion.identity);
            GameObject BM = GameObject.FindGameObjectsWithTag("BotonMuelle")[i];
            BM.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BM.transform.parent = CanvasButtons.transform;
            BM.GetComponent<buttonClick>().setIndex(i);
            BM.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - BM.GetComponent<RectTransform>().sizeDelta.x * BM.GetComponent<RectTransform>().localScale.x * i, -20, 0);
        }
        for (int i = 0; i < Game.getNumAceleradores(); i++)
        {
            Instantiate(ButtonAcelerador, Vector3.zero, Quaternion.identity);
            GameObject BA = GameObject.FindGameObjectsWithTag("BotonAcelerador")[i];
            BA.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BA.transform.parent = CanvasButtons.transform;
            BA.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles());
            BA.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * BA.GetComponent<RectTransform>().sizeDelta.x * BA.GetComponent<RectTransform>().localScale.x - BA.GetComponent<RectTransform>().sizeDelta.x * BA.GetComponent<RectTransform>().localScale.x * i, -20, 0);
        }

        /*
         * Get selected Level to Play from previous Scene (Map)
         * For the moment, we save a test number in levelToLoad
         */

        actualLevel = Game.getCurrentLevel();
        int tamanoCesped = 0;
        float sumaX = 0;
        float xMediaCesped = 0;
        float yCesped = 0;
        GameObject cespedInstanciado = new GameObject();
        Vector3 positionPlanoSobreCesped = new Vector3();

        for (int i = 0; i < actualLevel.mapElements.Count; i++)
        {
            for (int j = 0; j < actualLevel.mapElements[i].Count; j++)
            {
                Vector3 position = new Vector3(j, i + 1, 0);

                if (actualLevel.mapElements[i][j] == AIRE)
                {
                    Instantiate(Aire, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == TIERRA)
                {
                    Instantiate(Tierra, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CESPED)
                {
                    positionPlanoSobreCesped = position + new Vector3(0, 0.51f, 0);
                    Instantiate(PlanoSuelo, positionPlanoSobreCesped, Quaternion.identity);
                    if (tamanoCesped == 0)
                    {
                        cespedInstanciado = Instantiate(Cesped, position, Quaternion.identity) as GameObject;
                        sumaX = position.x;
                        tamanoCesped += 1;
                        yCesped = i;
                        Debug.Log(position);
                    }
                    else
                    {
                        tamanoCesped += 1;
                        sumaX += position.x;
                    }

                    if (j+1 >= actualLevel.mapElements[i].Count || (j+1 < actualLevel.mapElements[i].Count && actualLevel.mapElements[i][j + 1] != CESPED) )
                    {
                        xMediaCesped = sumaX / tamanoCesped;
                        cespedInstanciado.transform.position = new Vector3(xMediaCesped, cespedInstanciado.transform.position.y, cespedInstanciado.transform.position.z);
                        cespedInstanciado.transform.localScale = new Vector3(cespedInstanciado.transform.localScale.x * tamanoCesped, cespedInstanciado.transform.localScale.y, cespedInstanciado.transform.localScale.z);
                        foreach (Material m in cespedInstanciado.GetComponent<Renderer>().materials) {
                            m.mainTextureScale = new Vector2(tamanoCesped, 1);
                        }
                        tamanoCesped = 0;
                        sumaX = 0;
                        xMediaCesped = 0;
                        cespedInstanciado = new GameObject();
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
                    Instantiate(LevelEnd, new Vector3(position.x, position.y + 2, position.z), Quaternion.identity);
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
