using UnityEngine;
using System.Collections;

public class SonidoContinuo : MonoBehaviour {

    void Awake ()
    {
        GameObject go = GameObject.Find("MusicRandom");
        if (go == null) DontDestroyOnLoad(this.gameObject);
        else Destroy(this.gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

