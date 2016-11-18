using UnityEngine;
using System.Collections;

public class TocarPortalEntrada : MonoBehaviour {

    private GameObject cory;
    private GameObject portalSalida;
    private float speed;
    private Vector3 speedBeforeColliding;

    void Update()
    {
        if (cory != null)
        {
            this.transform.LookAt(cory.transform);
        }

        if (Game.isCoryInsidePortal())
        {
            if (cory.transform.position != portalSalida.transform.position)
            {
                float step = speed * Time.deltaTime;
                cory.transform.position = Vector3.MoveTowards(cory.transform.position, portalSalida.transform.position, step);
            } else
            {
                Game.setCoryInsidePortal(false);
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

    // Use this for initialization
    void Start()
    {
        Game.setCoryInsidePortal(false);
        cory = GameObject.FindGameObjectWithTag("Player");
        portalSalida = GameObject.FindGameObjectWithTag("PortalSalida");
        speed = 25;
        speedBeforeColliding = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == cory.tag && !Game.getCoryDie())
        {
            speedBeforeColliding = cory.GetComponent<Rigidbody>().velocity;
            cory.GetComponent<Rigidbody>().isKinematic = false; 
            cory.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            cory.GetComponent<SphereCollider>().enabled = false;
            cory.GetComponent<MeshRenderer>().enabled = false;
            cory.GetComponent<TrailRenderer>().enabled = false;
            Game.setCoryInsidePortal(true);
        }
    }
}
