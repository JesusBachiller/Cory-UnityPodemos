using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreaEscenario : MonoBehaviour
{

    private const int buttonOffset = 4;

    private const char AIRE = '0';
    private const char TIERRA = '1';
    private const char CESPED = '2';
    private const char AGUA = '3';
    private const char PINCHO = '4';
    private const char PLATAFORMA_ROTATORIA_DOS = '5';
    private const char PLATAFORMA_ROTATORIA_TRES = '6';
    private const char PLATAFORMA_ROTATORIA_CUATRO = '7';
    private const char PLATAFORMA_ROTATORIA_CINCO = '8';
    private const char CORY = '9';
    private const char ESTRELLA_UNO = 'a';
    private const char ESTRELLA_DOS = 'b';
    private const char ESTRELLA_TRES = 'c';
    private const char LEVEL_END = 'p';
    private const char HIELO = 'h';
    private const char FUEGO = 'f';

    public GameObject Aire;
    public GameObject Tierra;
    public GameObject Cesped;
    public GameObject PlanoSuelo;
    public GameObject Agua;
    public GameObject Pincho;
    public GameObject PlataformaRotatoriaDos;
    public GameObject PlataformaRotatoriaTres;
    public GameObject PlataformaRotatoriaCuatro;
    public GameObject PlataformaRotatoriaCinco;
    public GameObject Cory;
    public GameObject LevelEnd;
    public GameObject EstrellaUno;
    public GameObject EstrellaDos;
    public GameObject EstrellaTres;
    public GameObject Hielo;
    public GameObject Fuego;

    public GameObject CanvasComments;
    public GameObject CanvasButtons;
    public GameObject ButtonMuelle;
    public GameObject ButtonAcelerador;
    public GameObject ButtonFireState;
    public GameObject ButtonIceState;
    public GameObject ButtonPortal;

    public GameObject ScoreCanvas;

    public GameObject PriceTools;

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
            BM.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - (BM.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BM.GetComponent<RectTransform>().localScale.x * i, -20, 0); // x, y, z
        }
        for (int i = 0; i < Game.getNumAceleradores(); i++)
        {
            Instantiate(ButtonAcelerador, Vector3.zero, Quaternion.identity);
            GameObject BA = GameObject.FindGameObjectsWithTag("BotonAcelerador")[i];
            BA.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BA.transform.parent = CanvasButtons.transform;
            BA.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles());
            BA.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * (BA.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BA.GetComponent<RectTransform>().localScale.x - // x
                                                                                (BA.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BA.GetComponent<RectTransform>().localScale.x * i, // x,
                                                                            -20, // y
                                                                            0); // z
        }
        for (int i = 0; i < Game.getNumFireState(); i++)
        {
            Instantiate(ButtonFireState, Vector3.zero, Quaternion.identity);
            GameObject BFS = GameObject.FindGameObjectsWithTag("BotonFireState")[i];
            BFS.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BFS.transform.parent = CanvasButtons.transform;
            BFS.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles() + Game.getNumAceleradores());
            BFS.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumAceleradores() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x * i, // x,
                                                                            -20, // y
                                                                            0);  // z
        }

        for (int i = 0; i < Game.getNumIceState(); i++)
        {
            Instantiate(ButtonIceState, Vector3.zero, Quaternion.identity);
            GameObject BFS = GameObject.FindGameObjectsWithTag("BotonIceState")[i];
            BFS.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BFS.transform.parent = CanvasButtons.transform;
            BFS.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState());
            BFS.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumAceleradores() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumFireState() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x * i, // x,
                                                                            -20, // y
                                                                            0);  // z
        }

        for (int i = 0; i < Game.getNumPortales(); i++)
        {
            Instantiate(ButtonPortal, Vector3.zero, Quaternion.identity);
            GameObject BFS = GameObject.FindGameObjectsWithTag("BotonPortal")[i];
            BFS.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BFS.transform.parent = CanvasButtons.transform;
            BFS.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState());
            BFS.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumAceleradores() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    Game.getNumFireState() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumIceState() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -// x
                                                                                    (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x * i, // x,
                                                                            -20, // y
                                                                            0);  // z
        }

        /*for (int i = 0; i < Game.getNumIceState(); i++)
        {
            Instantiate(ButtonIceState, Vector3.zero, Quaternion.identity);
            GameObject BFS = GameObject.FindGameObjectsWithTag("BotonIceState")[i];
            BFS.GetComponent<RectTransform>().localScale = new Vector3((float)(Screen.width - Screen.height) / 300, (float)(Screen.width - Screen.height) / 300, 0);
            BFS.transform.parent = CanvasButtons.transform;
            BFS.GetComponent<buttonClick>().setIndex(i + Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() +  Game.getNumPortales());
            BFS.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20 - Game.getNumMuelles() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x -
                                                                                    Game.getNumAceleradores() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    Game.getNumFireState() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    Game.getNumPortales() * (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x - // x
                                                                                    (BFS.GetComponent<RectTransform>().sizeDelta.x + buttonOffset) * BFS.GetComponent<RectTransform>().localScale.x * i, // x,
                                                                            -20, // y
                                                                            0);  // z
        }*/


        GameObject PT = Instantiate(PriceTools, new Vector3(-5f, -5f, -5f), Quaternion.identity) as GameObject;
        PT.transform.parent = CanvasButtons.transform;


        /*
         * Get selected Level to Play from previous Scene (Map)
         * For the moment, we save a test number in levelToLoad
         */


        // ESTO PINTA PLANOS SOBRE LOS CUBOS
        actualLevel = Game.getCurrentLevel();
        ScoreCanvas = GameObject.Find("Score");
        ScoreCanvas.GetComponent<Text>().text = ("Score: " + actualLevel.startScore.ToString());
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

                if(actualLevel.mapElements[i][j] == HIELO)
                {
                    Instantiate(Hielo, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == FUEGO)
                {
                    Instantiate(Fuego, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == ESTRELLA_UNO)
                {
                    Instantiate(EstrellaUno, position, Quaternion.identity);

                }
                if (actualLevel.mapElements[i][j] == ESTRELLA_DOS)
                {
                    Instantiate(EstrellaDos, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == ESTRELLA_TRES)
                {
                    Instantiate(EstrellaTres, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == AIRE)
                {
                    Instantiate(Aire, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == TIERRA)
                {
                    GameObject tierra = Instantiate(Tierra, position, Quaternion.identity) as GameObject;

                    float color = UnityEngine.Random.Range(0.85f, 1f);
                    foreach (Material m in tierra.GetComponent<Renderer>().materials)
                    {
                        m.color = ActualizaEscenario.HSVToRGB(0, 0, color);
                    }
                }
                if (actualLevel.mapElements[i][j] == CESPED)
                {
                    Vector3 rotacionPlano = new Vector3();
                    float colorTierra = UnityEngine.Random.Range(0.85f, 1f);
                    GameObject cesped = null;

                    if (i == 0)  // first row
                    {
                        cesped = Instantiate(Cesped, position, Quaternion.identity) as GameObject;

                        // Ponemos plano encima y sin rotarlo
                        positionPlanoSobreCesped = position + new Vector3(0, 0.51f, 0);
                        rotacionPlano = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        if (i == actualLevel.mapElements.Count - 2)     // last row
                        {
                            if(actualLevel.mapElements[i - 1][j] != TIERRA)
                            {
                                cesped = Instantiate(Cesped, position, Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject;

                                // Ponemos plano debajo y rotado 180
                                positionPlanoSobreCesped = position + new Vector3(0, -0.51f, 0);
                                rotacionPlano = new Vector3(0, 0, 180);
                            }
                            else
                            {
                                cesped = Instantiate(Cesped, position, Quaternion.identity) as GameObject;

                                // Ponemos plano encima y sin rotarlo
                                positionPlanoSobreCesped = position + new Vector3(0, 0.51f, 0);
                                rotacionPlano = new Vector3(0, 0, 0);
                            }
                        }
                        else    // Midel rows
                        {
                            if (actualLevel.mapElements[i + 1][j] == TIERRA || actualLevel.mapElements[i + 1][j] == CESPED)
                            {
                                cesped = Instantiate(Cesped, position, Quaternion.Euler(new Vector3(0, 0, 180))) as GameObject;

                                // Ponemos plano debajo y rotado 180
                                positionPlanoSobreCesped = position + new Vector3(0, -0.51f, 0);
                                rotacionPlano = new Vector3(0, 0, 180);
                            }
                            else
                            {
                                cesped = Instantiate(Cesped, position, Quaternion.identity) as GameObject;

                                // Ponemos plano encima y sin rotarlo
                                positionPlanoSobreCesped = position + new Vector3(0, 0.51f, 0);
                                rotacionPlano = new Vector3(0, 0, 0);
                            }
                        }
                    }

                    //foreach (Material m in cesped.transform.FindChild("TierraDelCesped").GetComponent<Renderer>().materials)
                    foreach (Material m in cesped.transform.GetComponent<Renderer>().materials)
                    {
                        m.color = ActualizaEscenario.HSVToRGB(0, 0, colorTierra);
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
                    position.y -= 0.1f;
                    Instantiate(Agua, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == PINCHO)
                {
                    Instantiate(Pincho, position, Quaternion.identity);
                }
                if (actualLevel.mapElements[i][j] == PLATAFORMA_ROTATORIA_DOS)
                {
                    GameObject PR = Instantiate(PlataformaRotatoriaDos, position, Quaternion.identity) as GameObject;
                }
                if (actualLevel.mapElements[i][j] == PLATAFORMA_ROTATORIA_TRES)
                {
                    GameObject PR = Instantiate(PlataformaRotatoriaTres, position, Quaternion.identity) as GameObject;
                }
                if (actualLevel.mapElements[i][j] == PLATAFORMA_ROTATORIA_CUATRO)
                {
                    GameObject PR = Instantiate(PlataformaRotatoriaCuatro, position, Quaternion.identity) as GameObject;
                }
                if (actualLevel.mapElements[i][j] == PLATAFORMA_ROTATORIA_CINCO)
                {
                    GameObject PR = Instantiate(PlataformaRotatoriaCinco, position, Quaternion.identity) as GameObject;

                    /*PR.GetComponent<PlataformaRotatoria>().index = GameObject.FindGameObjectsWithTag("PlataformaRotatoria").Length - 1;
                    PR.name = "PlataformaRotatoria" + PR.GetComponent<PlataformaRotatoria>().index.ToString();
                    PR.GetComponentInChildren<RotarPlataformaRotatoria>().index = PR.GetComponent<PlataformaRotatoria>().index;*/
                }
                if (actualLevel.mapElements[i][j] == LEVEL_END)
                {
                    Instantiate(LevelEnd, new Vector3(position.x + 2, position.y - 0.025f, position.z), Quaternion.identity);
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
