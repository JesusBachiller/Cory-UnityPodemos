using UnityEngine;
using System.Collections;

public class ImpulsoAcelerador : MonoBehaviour {

    public float fuerza;
    private float maxVelocity;

    private Vector3 vectorDirectorNormalized;

    private float timeStayTrigger = 0;

    void Start()
    {
        fuerza = 2f;
        maxVelocity = 15f;

        vectorDirectorNormalized = Vector3.up;
    }

    public void changeForce(Vector3 Vnormal)
    {
        vectorDirectorNormalized = Vnormal;
        //Debug.Log(vectorDirectorNormalized);
    }

    void OnTriggerStay(Collider other)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("acelerat1"));
        Vector3 velocity = other.gameObject.GetComponent<Rigidbody>().velocity;

        float magnitude = velocity.magnitude;
        magnitude += fuerza;
        //Debug.Log("m: " + Mathf.Min(magnitude, maxVelocity));

        other.gameObject.GetComponent<Rigidbody>().velocity = vectorDirectorNormalized * (Mathf.Min(magnitude, maxVelocity));
    }

}
