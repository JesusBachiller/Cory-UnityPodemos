using UnityEngine;
using System.Collections;

public class PortalSalida : MonoBehaviour {

    private GameObject cory;

    // Use this for initialization
    void Start ()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(cory != null) {
            this.transform.LookAt(cory.transform);
        }
    }
}
