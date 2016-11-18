using UnityEngine;
using System.Collections;

public class rotateStar : MonoBehaviour {

    private Vector3 rotacion;

    void Start()
    {
        rotacion = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotacion = rotacion + new Vector3(0, 0, Random.Range(2,4));
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x+ rotacion.x, transform.rotation.y+ rotacion.y, transform.rotation.z+ rotacion.z));
    }
}
