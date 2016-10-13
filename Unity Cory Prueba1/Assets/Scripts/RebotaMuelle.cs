using UnityEngine;
using System.Collections;

public class RebotaMuelle : MonoBehaviour {
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            /*int fuerzaEnX = 6;
            int fuerzaEnY = 10;
            int fuerzaEnZ = 0;

            if(col.rigidbody.velocity.x < 0) // Si va hacia izquierda
            {
                fuerzaEnX *= -1; // Impulsar hacia izquierda
            }
            if (col.rigidbody.velocity.y > 0) // Si va hacia arriba
            {
                fuerzaEnY *= -1; // Impulsar hacia abajo
            }
            */
            col.gameObject.GetComponent<Rigidbody>().AddForce(col.gameObject.GetComponent<Rigidbody>().velocity.x * 1.05f,
                                                              col.gameObject.GetComponent<Rigidbody>().velocity.y * 1.05f,
                                                              col.gameObject.GetComponent<Rigidbody>().velocity.z,
                                                              ForceMode.Impulse);
            Debug.Log(col.gameObject.GetComponent<Rigidbody>().velocity);
        }
    }
}
