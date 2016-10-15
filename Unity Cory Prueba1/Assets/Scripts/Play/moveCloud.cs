using UnityEngine;
using System.Collections;

public class moveCloud : MonoBehaviour {

    private float Velocity;
	
    void Start()
    {
        Velocity = Random.Range(0.01f, 0.02f);
    }

	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x - Velocity, transform.position.y, transform.position.z);

        if (transform.position.x <= -35f)
        {
            transform.position = new Vector3(82.2f, Random.Range(3f, 13f), transform.position.z);
        }
	}
}
