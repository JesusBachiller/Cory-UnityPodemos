using UnityEngine;
using System.Collections;

public class RebotaMuelle : MonoBehaviour {
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Rigidbody>().AddForce(col.gameObject.GetComponent<Rigidbody>().velocity.x,
                                                              col.gameObject.GetComponent<Rigidbody>().velocity.y,
                                                              col.gameObject.GetComponent<Rigidbody>().velocity.z,
                                                              ForceMode.Impulse);
        }
    }
}
