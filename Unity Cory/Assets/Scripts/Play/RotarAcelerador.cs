using UnityEngine;
using System.Collections;

public class RotarAcelerador : MonoBehaviour {

    GameObject Acelerador;

    public Vector3 poss_init;
    public Vector3 poss_end;

    public Vector3 v_Init_End;

    public float rad;
    public float degrees;

    void Start () {
        Acelerador = null;

        poss_init = Vector3.zero;
        poss_end = Vector3.zero;

        v_Init_End = Vector3.zero;

        rad = 0f;
        degrees = 0f;

    }

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
            {
                permite = false;
                break;
            }
        }
        if (permite)
        {
            for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
            {
                if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }
        return permite;
    }

    private void OnRightClick()
    {
        // Cast a ray from the mouse
        // cursors position
        Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPoint;

        // See if the ray collided with an object
        if (Physics.Raycast(clickPoint, out hitPoint))
        {
            // Make sure this object was the
            // one that received the right-click
            if (hitPoint.collider == this.GetComponent<Collider>())
            {
                // Put code for the right click event
                Debug.Log("Right Clicked on " + this.name);
                Acelerador = this.gameObject;
            }
        }
    }

    private void rotateAcelerador()
    {
        if (poss_init != Vector3.zero && poss_end != Vector3.zero)
        {
            v_Init_End = new Vector3(poss_end.x - poss_init.x, poss_end.y - poss_init.y, poss_end.z - poss_init.z);
            //Debug.Log(v_Init_End);
            //Debug.Log(v_Init_End.normalized);

            if (v_Init_End.y != 0)
            {
                rad = Mathf.Atan(v_Init_End.x / v_Init_End.y);
                //Debug.Log("Radianes: " + rad);
                degrees = rad * 180f / Mathf.PI;
                if (v_Init_End.y < 0)
                {
                    degrees += 180;
                }
                //Debug.Log("grados: " + degrees);

                Acelerador.transform.eulerAngles = new Vector3(0f, 0f, -degrees);

                //Debug.Log(Acelerador.transform.eulerAngles);
            }

        }

    }

    void Update()
    {
        if (permitirClick())
        {
            if (Input.GetMouseButtonDown(1))
            {
                OnRightClick();
                if (Acelerador != null)
                {
                    poss_init = Input.mousePosition;
                }
            }
            else
            {
                if (Acelerador != null)
                {
                    if (Input.GetMouseButton(1))
                    {
                        poss_end = Input.mousePosition;
                    }
                    else
                    {
                        if (poss_init != Vector3.zero && poss_end != Vector3.zero)
                        {
                            Acelerador.GetComponent<ImpulsoAcelerador>().changeForce(v_Init_End.normalized);
                            reseltValues();
                        }
                    }
                }
            }
            if (Acelerador != null)
            {
                if (poss_init != Vector3.zero && poss_end != Vector3.zero)
                {
                    rotateAcelerador();
                }
            }
        }
    }

    private void reseltValues()
    {

        poss_init = Vector3.zero;
        poss_end = Vector3.zero;

        v_Init_End = Vector3.zero;


        rad = 0;
        degrees = 0;

        Acelerador = null;
    }
}
