using UnityEngine;
using System.Collections;

public class moveCar : MonoBehaviour
{

    private float Velocity;

    void Start()
    {
        Velocity = 0.15f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + Velocity, transform.position.y, transform.position.z);

        if (transform.position.x >= 59f)
        {
            Velocity = 0;
        }
    }
}
