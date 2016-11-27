using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lanzamiento : MonoBehaviour
{

    private Vector3 posInicial_Mouse;
    private Vector3 posFinal_Mouse;

    private float fuerzaExtra;
    private float factorEscalado;

    private int maxDistancia;

    private Vector3 velocidad;
    private float moduloVelocidad;

    public float AlcanceMax;
    
    private int samples;
    
    private Vector3 posInitCory;

    private Vector3 home;
    private GameObject[] argo;
    private bool freeze;
    private float spacing;

    private bool AnuladoLanzamiento;

    void Start()
    {
        samples = 20;
        freeze = true;
        spacing = 0.025f;

        posInitCory = transform.position;
        home = transform.position;
        home.y = -2;

        argo = new GameObject[samples];
        for (var i = 0; i < argo.Length; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.GetComponent<Collider>().enabled = false;
            go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            argo[i] = go;
        }


        maxDistancia = 775;

        fuerzaExtra = 40f;

        velocidad = new Vector3(0f, 0f, 0f);

        AnuladoLanzamiento = false;

    }

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0;
                 i < Game.getNumMuelles();
                 i++)
        {   
            if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
            {
                permite = false;
                break;
            }
        }

        for (int i = Game.getNumMuelles();
                 i < Game.getNumMuelles() + Game.getNumAceleradores();
                 i++)
        {
            if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
            {
                permite = false;
                break;
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i++)
        {
            if (Game.getBotonFireStateActivado(i) == true && Game.getFireStatePuesto(i) == false)
            {
                permite = false;
                break;
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                 i++)
        {
            if (Game.getBotonIceStateActivado(i) == true && Game.getIceStatePuesto(i) == false)
            {
                permite = false;
                break;
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState() + Game.getNumPortales();
                 i++)
        {
            if (Game.getBotonPortalActivado(i) == true && Game.getPortalEntradaPuesto(i) == false)
            {
                permite = false;
                break;
            }
            if (Game.getBotonPortalActivado(i) == true && Game.getPortalSalidaPuesto(i) == false)
            {
                permite = false;
                break;
            }
        }

        if (Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
        }

        return permite;
    }

    private void ReturnHome()
    {
        for (var i = 0; i < argo.Length; i++)
        {
            argo[i].transform.position = home;
        }
        ShowHideIndicators(true);
    }
    
    private void ShowHideIndicators(bool show)
    {
        for (var i = 0; i < argo.Length; i++)
        {
            argo[i].GetComponent<Renderer>().enabled = show;
        }
    }

    private void DisplayIndicators()
    {
        velocidad /= 9.15f;
        argo[0].transform.position = transform.position;
        Vector3 v3 = transform.position;
        float y = velocidad.y;
        float t = 0.0f;
        v3.y = 0.0f;
        for (var i = 1; i < argo.Length; i++)
        {
            v3 += velocidad * spacing;
            t += spacing;
            v3.y = y * t + 0.5f * -300 * t * t + transform.position.y;
            argo[i].transform.position =v3;
        }
    }

    void OnMouseDown()
    {
        if (permitirClick())
        {
            posInicial_Mouse = Input.mousePosition;
            ShowHideIndicators(true);
        }
    }


    void OnMouseDrag()
    {
        if (permitirClick())
        {
            if (Input.GetMouseButtonDown(1))
            {
                ReturnHome();
                ShowHideIndicators(false);
                AnuladoLanzamiento = true;
            }
            else
            {
                if (!AnuladoLanzamiento)
                {
                    posFinal_Mouse = Input.mousePosition;

                    velocidad = posInicial_Mouse - posFinal_Mouse;
                    velocidad.x = ((velocidad.x * 100) / Screen.width) * fuerzaExtra;
                    velocidad.y = ((velocidad.y * 100) / Screen.height) * fuerzaExtra;

                    moduloVelocidad = Mathf.Sqrt((velocidad.x * velocidad.x) + (velocidad.y * velocidad.y));
                    if (moduloVelocidad >= maxDistancia)
                    {
                        velocidad.x = velocidad.x * maxDistancia / moduloVelocidad;
                        velocidad.y = velocidad.y * maxDistancia / moduloVelocidad;
                    }

                    DisplayIndicators();
                }
            }
        }
    }


    void OnMouseUp()
    {
        if (permitirClick())
        {
            if (AnuladoLanzamiento)
            {
                AnuladoLanzamiento = false;
            }
            else
            {
                Game.setCoryFly(true);

                ReturnHome();
                freeze = false;
                ShowHideIndicators(false);

                posFinal_Mouse = Input.mousePosition;

                Rigidbody rb = GetComponent<Rigidbody>();

                velocidad = posInicial_Mouse - posFinal_Mouse;
                velocidad.x = ((velocidad.x * 100) / Screen.width) * fuerzaExtra;
                velocidad.y = ((velocidad.y * 100) / Screen.height) * fuerzaExtra;

                moduloVelocidad = Mathf.Sqrt((velocidad.x * velocidad.x) + (velocidad.y * velocidad.y));
                if (moduloVelocidad < maxDistancia)
                {
                    rb.AddForce(velocidad.x, velocidad.y, velocidad.z);
                }
                else
                {
                    velocidad.x = velocidad.x * maxDistancia / moduloVelocidad;
                    velocidad.y = velocidad.y * maxDistancia / moduloVelocidad;

                    rb.AddForce(velocidad.x, velocidad.y, velocidad.z);
                }
            }
        }
    }

    public Vector3 getPosInitCory()
    {
        return posInitCory;
    }

}
