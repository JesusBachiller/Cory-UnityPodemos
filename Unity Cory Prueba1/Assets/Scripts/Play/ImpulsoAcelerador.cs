using UnityEngine;
using System.Collections;

public class ImpulsoAcelerador : MonoBehaviour {

    public float fuerza;

    void Start()
    {
        fuerza = 5f;
    }

    void OnTriggerEnter(Collider other)
    {
        Vector3 velocity = other.GetComponent<Rigidbody>().velocity;
        velocity.x += fuerza;
        velocity.y *= 0.85f;
        other.GetComponent<Rigidbody>().velocity = velocity;
    }

}
