using UnityEngine;
using System.Collections;

public class lanzamiento : MonoBehaviour {

    private Vector3 posInicial_Mouse;
    private Vector3 pos_Mouse;
    private Vector3 posFinal_Mouse;

    private int fuerzaExtra;

    private int maxDistancia;

    private Vector3 velocidad;
    private float moduloVelocidad;

    private float angulo_Lanzamiento;
    public float AlcanceMax;
    


    void Start () {
		
        maxDistancia = 90;

        fuerzaExtra = 7;

        velocidad = new Vector3(0, 0, 0);

	}

	void OnMouseDown() {
		posInicial_Mouse = Input.mousePosition;
        
	}
	
	void OnMouseUp() {
		posFinal_Mouse = Input.mousePosition;
		
		Rigidbody rb = GetComponent<Rigidbody>();
        

		velocidad.x = posInicial_Mouse.x - posFinal_Mouse.x;
		velocidad.y = posInicial_Mouse.y - posFinal_Mouse.y;

        moduloVelocidad = Mathf.Sqrt((velocidad.x * velocidad.x) + (velocidad.y * velocidad.y));
        if (moduloVelocidad < maxDistancia)
        {
            Debug.Log(moduloVelocidad);
            rb.AddForce(velocidad.z, velocidad.y * fuerzaExtra, velocidad.x * fuerzaExtra);
        }
        else
        {
            Debug.Log(velocidad.x);
            Debug.Log(velocidad.y);
            velocidad.x = velocidad.x * maxDistancia / moduloVelocidad;
            velocidad.y = velocidad.y * maxDistancia / moduloVelocidad;
            Debug.Log(velocidad.x);
            Debug.Log(velocidad.y);

            rb.AddForce(velocidad.z, velocidad.y * fuerzaExtra, velocidad.x * fuerzaExtra);
        }		
	}
}
