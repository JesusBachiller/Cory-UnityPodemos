using UnityEngine;
using System.Collections;

public class PathMov : MonoBehaviour {

    public float idx;
    
    private float onda;
    private float posYIni;

    void Start()
    {
        posYIni = transform.position.y;

        onda = 0f;

        GetComponent<Renderer>().material.color = Color.red;
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, posYIni + Mathf.Sin(onda - idx / 2) * 20, transform.position.z);
        onda += 0.020f;
    }
}
