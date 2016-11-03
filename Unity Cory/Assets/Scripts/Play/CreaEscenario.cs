using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreaEscenario : MonoBehaviour
{

    private const char AIRE = '0';
    private const char TIERRA = '1';
    private const char CESPED = '2';
    private const char AGUA = '3';
    private const char PINCHO = '4';
    private const char PLATAFORMA_ROTATORIA = '5';
    private const char LEVEL_END = '8';
    private const char CORY = '9';


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

        
        // ESTO PINTA PLANOS SOBRE LOS CUBOS
        actualLevel = Game.getCurrentLevel();
        int tamanoPlanoSobreCesped = 0;
        float sumaX = 0;
        float xMediaPlanoSobreCesped = 0;
        GameObject planoInstanciado = new GameObject();
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
                    Vector3 rotacionPlano = new Vector3();
                    if (i != 0 && actualLevel.mapElements[i - 1][j] == AIRE)
                    {
                        Instantiate(Cesped, position, Quaternion.Euler(new Vector3(0, 0, 180)));

                        // Ponemos plano debajo y sin rotado 180
                        positionPlanoSobreCesped = position + new Vector3(0, -0.51f, 0);
                        rotacionPlano = new Vector3(0, 0, 180);
                    }
                    else
                    {
                        Instantiate(Cesped, position, Quaternion.identity);

                        // Ponemos plano encima y sin rotarlo
                        positionPlanoSobreCesped = position + new Vector3(0, 0.51f, 0);
                        rotacionPlano = new Vector3(0, 0, 0);
                    }
                    if (tamanoPlanoSobreCesped == 0)
                    {
                        Vector3 posicionPlanoLateralIzquierdo = position + new Vector3(-0.51f, 0, 0);
                        Instantiate(PlanoSuelo, posicionPlanoLateralIzquierdo, Quaternion.Euler(new Vector3(0, 0, 90)));
                        planoInstanciado = Instantiate(PlanoSuelo, positionPlanoSobreCesped, Quaternion.Euler(rotacionPlano)) as GameObject;
                        sumaX = position.x;
                        tamanoPlanoSobreCesped += 1;
                    }
                    else
                    {
                        tamanoPlanoSobreCesped += 1;
                        sumaX += position.x;
                    }

                    if (j + 1 >= actualLevel.mapElements[i].Count || (j + 1 < actualLevel.mapElements[i].Count && actualLevel.mapElements[i][j + 1] != CESPED))
                    {
                        Vector3 posicionPlanoLateralDerecho = position + new Vector3(+0.51f, 0, 0);
                        Instantiate(PlanoSuelo, posicionPlanoLateralDerecho, Quaternion.Euler(new Vector3(0, 0, -90)));

                        xMediaPlanoSobreCesped = sumaX / tamanoPlanoSobreCesped;
                        planoInstanciado.transform.position = new Vector3(xMediaPlanoSobreCesped, planoInstanciado.transform.position.y, planoInstanciado.transform.position.z);
                        planoInstanciado.transform.localScale = new Vector3(planoInstanciado.transform.localScale.x * tamanoPlanoSobreCesped, planoInstanciado.transform.localScale.y, planoInstanciado.transform.localScale.z);
                        foreach (Material m in planoInstanciado.GetComponent<Renderer>().materials)
                        {
                            m.mainTextureScale = new Vector2(tamanoPlanoSobreCesped, 1);
                        }
                        tamanoPlanoSobreCesped = 0;
                        sumaX = 0;
                        xMediaPlanoSobreCesped = 0;
                        planoInstanciado = new GameObject();
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
                    GameObject PR = Instantiate(PlataformaRotatoria, position, Quaternion.identity) as GameObject;

                    /*PR.GetComponent<PlataformaRotatoria>().index = GameObject.FindGameObjectsWithTag("PlataformaRotatoria").Length - 1;
                    PR.name = "PlataformaRotatoria" + PR.GetComponent<PlataformaRotatoria>().index.ToString();
                    PR.GetComponentInChildren<RotarPlataformaRotatoria>().index = PR.GetComponent<PlataformaRotatoria>().index;*/
                }
                if (actualLevel.mapElements[i][j] == LEVEL_END)
                {
                    Instantiate(LevelEnd, new Vector3(position.x, position.y + 2, position.z), Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == CORY)
                {
                    Instantiate(Cory, position, Quaternion.Euler(new Vector3(0, 45, 120)));
                    Vector3 posCamara = new Vector3(position.x + 1, position.y + 6, position.z - 20.57f);
                    CamaraPrincipal.transform.localPosition = posCamara;
                    CamaraPrincipal.transform.rotation = Quaternion.Euler(new Vector3(7.5f, 22, 0));
                    //Instantiate(CamaraPrincipal, posCamara, Quaternion.Euler(new Vector3(15, -12, -2)));
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
