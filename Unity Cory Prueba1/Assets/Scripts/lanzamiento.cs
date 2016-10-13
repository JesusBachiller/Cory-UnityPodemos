using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lanzamiento : MonoBehaviour
{

    private Vector3 posInicial_Mouse;
    private Vector3 posFinal_Mouse;

    private float fuerzaExtra;

    private int maxDistancia;

    private Vector3 velocidad;
    private float moduloVelocidad;

    public float AlcanceMax;
    
    private int samples;

    private Vector3 home;
    private GameObject[] argo;
    private bool freeze;
    private Vector3 velocity;
    private float spacing;
    private float force;

    void Start()
    {
        samples = 20;
        freeze = true;
        velocity = new Vector3(0f, 0f, 0f);
        spacing = 0.025f;
        force = 1.0f;

        home = transform.position;
        home.y = -2;

        argo = new GameObject[samples];
        for (var i = 0; i < argo.Length; i++)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.GetComponent<Collider>().enabled = false;
            go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            argo[i] = go;
        }


        maxDistancia = 90;

        fuerzaExtra = 9.1f;

        velocidad = new Vector3(0f, 0f, 0f);


    }

    void FixedUpdate()
    {

    }

    private void ReturnHome()
    {
        for (var i = 0; i < argo.Length; i++)
        {
            argo[i].transform.position = home;
        }
        velocity = Vector3.zero;
        freeze = true;
        ShowHideIndicators(true);

    }
    
    private void ShowHideIndicators(bool show)
    {
        for (var i = 0; i < argo.Length; i++)
        {
            argo[i].GetComponent<Renderer>().enabled = show;
            argo[i].transform.position = home;
        }
    }

    private void DisplayIndicators()
    {
        Debug.Log("Entra");
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
        posInicial_Mouse = Input.mousePosition;     
    }


    void OnMouseDrag()
    {
        posFinal_Mouse = Input.mousePosition;


        velocidad = posInicial_Mouse - posFinal_Mouse;

        DisplayIndicators();
    }


    void OnMouseUp()
    {
        ReturnHome();
        freeze = false;
        ShowHideIndicators(false);
        posFinal_Mouse = Input.mousePosition;

        Rigidbody rb = GetComponent<Rigidbody>();


        velocidad = posInicial_Mouse - posFinal_Mouse;

        moduloVelocidad = Mathf.Sqrt((velocidad.x * velocidad.x) + (velocidad.y * velocidad.y));
        if (moduloVelocidad < maxDistancia)
        {
            //Debug.Log(moduloVelocidad);
            rb.AddForce(velocidad.x * fuerzaExtra, velocidad.y * fuerzaExtra, velocidad.z);
        }
        else
        {
            //Debug.Log(velocidad.x);
            //Debug.Log(velocidad.y);
            velocidad.x = velocidad.x * maxDistancia / moduloVelocidad;
            velocidad.y = velocidad.y * maxDistancia / moduloVelocidad;
            //Debug.Log(velocidad.x);
            //Debug.Log(velocidad.y);

            rb.AddForce(velocidad.x * fuerzaExtra, velocidad.y * fuerzaExtra, velocidad.z);
        }
    }

}
