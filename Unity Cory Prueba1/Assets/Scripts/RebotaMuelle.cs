using UnityEngine;
using System.Collections;

public class RebotaMuelle : MonoBehaviour {
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            int fuerzaEnX = 6;
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

            col.gameObject.GetComponent<Rigidbody>().AddForce(fuerzaEnX, fuerzaEnY, fuerzaEnZ, ForceMode.Impulse);
        }
    }
}
