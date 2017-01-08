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
    public GameObject marcadorPosiblePortal;

    public GameObject aireBlock; // Block of air where I am


    // Use this for initialization
    void Start()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
        portalSalida = null;
        speed = 25;
        speedBeforeColliding = new Vector3(0, 0, 0);
    }

    void LateUpdate()
    {
        if (cory != null)
        {
            this.transform.LookAt(cory.transform);
        }

        if (Game.isCoryInsidePortal(index) && portalSalida != null)
        {
            if (Vector3.Distance(cory.transform.position, portalSalida.transform.position) > 0.5)
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

                foreach (GameObject Partc in GameObject.FindGameObjectsWithTag("ParticleFire"))
                {
                    Partc.GetComponent<ParticleSystem>().Play();
                }
                foreach (GameObject Partc in GameObject.FindGameObjectsWithTag("ParticleIce"))
                {
                    Partc.GetComponent<ParticleSystem>().Play();
                }

                speedBeforeColliding = new Vector3(0, 0, 0);
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("portal3"));
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

            foreach (GameObject Partc in GameObject.FindGameObjectsWithTag("ParticleFire"))
            {
                Partc.GetComponent<ParticleSystem>().Stop();
            }
            foreach (GameObject Partc in GameObject.FindGameObjectsWithTag("ParticleIce"))
            {
                Partc.GetComponent<ParticleSystem>().Stop();
            }

            Game.setCoryInsidePortal(index, true);
        }
    }

    private bool permitirClick()
    {
        bool permite = true;
        for (int i = 0;
                 i < Game.getNumMuelles();
                 i++)
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

        for (int i = Game.getNumMuelles();
                 i < Game.getNumMuelles() + Game.getNumAceleradores();
                 i++)
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

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i++)
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

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                 i++)
        {
            if (i != index)
            {
                if (Game.getBotonIceStateActivado(i) == true && Game.getIceStatePuesto(i) == false)
                {
                    permite = false;
                    break;
                }
            }
        }

        for (int i = Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState();
                 i < Game.getNumMuelles() + Game.getNumAceleradores() + Game.getNumFireState() + Game.getNumIceState() + Game.getNumPortales();
                 i++)
        {
            if (i != index)
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
            else
            {
                if(Game.getBotonPortalActivado(i) == true && Game.getPortalEntradaPuesto(i) == true)
                {
                    if (Game.getPortalSalidaPuesto(i) == false)
                    {
                        permite = false;
                        break;
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
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalEntrada();
                GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 2.0f);

                hideAllIndicators();

                GameObject[] PortalesSalida = GameObject.FindGameObjectsWithTag("PortalSalida");
                foreach (GameObject pS in PortalesSalida)
                {
                    if (pS.GetComponent<PortalSalida>().getIndex() == index)
                    {
                        pS.transform.position = new Vector3(-10, -10, 0);
                        Game.setPortalSalidaPuesto(index, false);
                        if (pS.GetComponent<PortalSalida>().getAireBlock() != null)
                        {
                            pS.GetComponent<PortalSalida>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                        }
                    }
                }
            }
            else
            {
                // Pongo portal
                Game.setPortalEntradaPuesto(index, true);
                aireBlock.GetComponent<MouseOverPossibleAcelerador>().setContainTool(true);
                creaEscenario.GetComponent<ActualizaEscenario>().NotEnableDestroyPossiblePortalEntrada();
                Color c = transform.FindChild("AroExterior").gameObject.GetComponent<MeshRenderer>().materials[0].color; // cojo el color del Aro Exterior

                bool crearPortalSalida = true; // Si estoy poniendo el portal entrada, aun no he instanciado el portalSalida
                GameObject[] PortalesSalida = GameObject.FindGameObjectsWithTag("PortalSalida");
                foreach (GameObject pS in PortalesSalida)
                {
                    if (pS.GetComponent<PortalSalida>().getIndex() == index) // Si estoy moviendo el portal entrada, ya existe el portalSalida
                    {
                        crearPortalSalida = false; // Por tanto no instancio otro portalSalida
                    }
                }
                if (crearPortalSalida)
                {
                    creaEscenario.GetComponent<ActualizaEscenario>().InstanciatePortalSalida(index, c); // y se lo paso al portalSalida para que sea del mismo color
                    creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalSalida();
                }

                showIndicators();

                foreach (GameObject pS in PortalesSalida)
                {
                    if (pS.GetComponent<PortalSalida>().getIndex() == index) // Si estoy moviendo el portal entrada, ya existe el portalSalida
                    {
                        Game.setPortalSalidaPuesto(index, false);
                        if (pS.GetComponent<PortalSalida>().getAireBlock() != null)
                        {
                            pS.GetComponent<PortalSalida>().getAireBlock().GetComponent<MouseOverPossibleAcelerador>().setContainTool(false);
                        }
                        creaEscenario.GetComponent<ActualizaEscenario>().EnablePossiblePortalSalida();
                    }
                }
                GetComponent<BoxCollider>().size = new Vector3(1.0f, 1.0f, 1.0f);
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

    public GameObject getAireBlock()
    {
        return aireBlock;
    }

    public void showIndicators()
    {
        // Crear paneles traseros indicativos del radio posible de distancia del portal de salida
        for (float x = transform.position.x - Game.RADIO_MAX_PORTALES; x <= transform.position.x + Game.RADIO_MAX_PORTALES; x = x + 1)
        {
            for (float y = transform.position.y - Game.RADIO_MAX_PORTALES; y <= transform.position.y + Game.RADIO_MAX_PORTALES; y = y + 1)
            {
                foreach (GameObject air in GameObject.FindGameObjectsWithTag("Aire"))
                {
                    if (air.transform.position.x == x && air.transform.position.y == y && air.GetComponent<MouseOverPossibleAcelerador>().getContainTool() == false)
                    {
                        Instantiate(marcadorPosiblePortal, new Vector3(x, y, 0.75f), Quaternion.Euler(new Vector3(-90, 0, 0)));
                    }
                }
            }
        }
    }

    public static void hideAllIndicators()
    {
        GameObject[] marcadoresPosiblePortal = GameObject.FindGameObjectsWithTag("MarcadorPosiblePortal");
        foreach (GameObject marcador in marcadoresPosiblePortal)
        {
            Destroy(marcador);
        }
    }
}