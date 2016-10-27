﻿using UnityEngine;
using System.Collections;

public class MataCoryPincho : MonoBehaviour {

    public GameObject cory;

	// Use this for initialization
	void Start () {
        cory = GameObject.FindGameObjectWithTag("Player");
	}
    

    // Update is called once per frame
    void OnCollisionEnter (Collision col)
    {
        if (col.gameObject.tag == cory.tag)
        {
            Game.setCoryDie(true);
            Game.setCoryFly(false);
            StartCoroutine(changePositionCory(2));
            cory.GetComponent<TrailRenderer>().enabled = false;
        }
	}

    IEnumerator changePositionCory(float s)
    {
        cory.GetComponent<Rigidbody>().isKinematic = true;

        yield return new WaitForSeconds(s);

        Vector3 posInit = cory.GetComponent<lanzamiento>().getPosInitCory();
        cory.transform.position = posInit;
        cory.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 120));

        cory.GetComponent<Rigidbody>().isKinematic = false;
        cory.GetComponent<TrailRenderer>().enabled = true;
        Game.setCoryDie(false);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().setCameraFollowPlayer(true);
        
    }
}