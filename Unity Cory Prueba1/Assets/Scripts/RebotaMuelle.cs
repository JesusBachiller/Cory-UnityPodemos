using UnityEngine;
using System.Collections;

public class RebotaMuelle : MonoBehaviour {
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(0, 3, 3,ForceMode.Impulse);
        }
    }
}
