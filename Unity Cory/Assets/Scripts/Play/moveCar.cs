using UnityEngine;
using System.Collections;

public class moveCar : MonoBehaviour
{

    private float Velocity;
    private float zInicial;

    void Start()
    {
        Velocity = 0.15f;
        zInicial = transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x <= 125f)
        {
            transform.position = new Vector3(transform.position.x + Velocity, transform.position.y, transform.position.z);
        } else
        {
            if (transform.position.z == zInicial)
            {
                transform.rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
            }
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Velocity);
            if (transform.position.z <= -16f){
                transform.position = new Vector3( -64.7f, 2.2f, 23.3f);
                transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            }
        }
    }
}
