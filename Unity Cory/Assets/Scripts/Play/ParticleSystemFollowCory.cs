using UnityEngine;
using System.Collections;

public class ParticleSystemFollowCory : MonoBehaviour {

    private GameObject cory;

    public bool isStopped;
    
	void Start () {
        cory = GameObject.FindGameObjectWithTag("Player");

        isStopped = false;
	}
	
	void Update () {
        transform.position = cory.transform.position;
	}

    public void setIsStopped(bool b)
    {
        isStopped = b;
    }
    public bool getIsStopped()
    {
        return isStopped;
    }
}
