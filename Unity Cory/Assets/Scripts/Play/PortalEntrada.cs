using UnityEngine;
using System.Collections;

public class PortalEntrada : MonoBehaviour
{
    private GameObject cory;
    private GameObject portalSalida;
    private float speed;
    private Vector3 speedBeforeColliding;
    public int index;
    public GameObject creaEscenario;

    public GameObject aireBlock; // Block of air where I am


    // Use this for initialization
    void Start()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
        portalSalida = null;
        speed = 25;
        speedBeforeColliding = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (cory != null)
        {
            this.transform.LookAt(cory.transform);
        }

        if (Game.isCoryInsidePortal(index) && portalSalida != null)
        {            
            if (cory.transform.position != portalSalida.transform.position)
            {
                float step = speed * Time.deltaTime;
                cory.transform.position = Vector3.MoveTowards(cory.transform.position, portalSalida.transform.position, step);
            }
            else
            {
                Game.setCoryInsidePortal(index, false);
                cory.GetComponent<SphereCollider>().enabled = true;
                cory.GetComponent<Rigidbody>().isKinematic = false;
                cory.GetComponent<Rigidbody>().velocity = speedBeforeColliding;
                cory.GetComponent<MeshRenderer>().enabled = true;
                cory.GetComponent<TrailRenderer>().Clear();
                cory.GetComponent<TrailRenderer>().enabled = true;
                speedBeforeColliding = new Vector3(0, 0, 0);
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == cory.tag && !Game.getCoryDie())
        {
            foreach (GameObject pS in GameObject.FindGameObjectsWithTag("PortalSalida"))
            {
                if (pS.GetComponent<PortalSalida>().getIndex() == index)
                {
                    portalSalida = pS;
                }
            }
            speedBeforeColliding = cory.GetComponent<Rigidbody>().velocity;
            cory.GetComponent<Rigidbody>().isKinematic = false;
            cory.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            cory.GetComponent<SphereCollider>().enabled = false;
            cory.GetComponent<MeshRenderer>().enabled = false;
            cory.GetComponent<TrailRenderer>().enabled = false;
            Game.setCoryInsidePortal(index, true);
        }
    }

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0; i < Game.getNumMuelles(); i++)
        {
            if (i != index)
            {
                if (Game.getBotonMuelleActivado(i) == true && Game.getMuellePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }
        if (permite)
        {
            for (int i = Game.getNumMuelles(); i < Game.getNumMuelles() + Game.getNumAceleradores(); i++)
            {
                if (i != index)
                {
                    if (Game.getBotonAceleradorActivado(i) == true && Game.getAceleradorPuesto(i) == false)
                    {
                        permite = false;
                        break;
                    }
                }
            }
            if (permite)
            {
                for (int i = Game.getNumMuelles() + Game.getNumAceleradores(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i++)
                {
                    if (i != index)
                    {
                        if (Game.getBotonFireStateActivado(i) == true && Game.getFireStatePuesto(i) == false)
                        {
                            permite = false;
                            break;
                        }
                    }
                }
                if (permite)
                {
                    for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState(); i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumPortales(); i++)
                    {
                        if (i != index)
                        {
                            if (Game.getBotonPortalActivado(i) == true && (Game.getPortalEntradaPuesto(i) == false || Game.getPortalSalidaPuesto(i) == false))
                            {
                                permite = false;
                                break;
                            }
                        }
                    }
                }
            }

        }
        if (Game.getCoryFly() || Game.getCoryEnd() || Game.getCoryDie())
        {
            permite = false;
        }

        return permite;
    }

    void OnMouseDown()
    {
        if (permitirClick())
        {
            if (Game.getPortalEntradaPuesto(index))
            {
                // Muevo portal
                Game.setPortalEntradaPuesto(index, false);
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(true);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalEntrada();
            }
            else
            {
                // Pongo portal
                Game.setPortalEntradaPuesto(index, true);
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossiblePortalEntrada();

                creaEscenario.GetComponent<ActualizaEscenario>().InstanciatePortalSalida(index);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalSalida();
            }
        }
    }

    public void setIndex(int i)
    {
        index = i;
    }
    public int getIndex()
    {
        return index;
    }

    public void setAireBlock(GameObject a)
    {
        aireBlock = a;
    }
}