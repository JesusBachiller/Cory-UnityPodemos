using UnityEngine;
using System.Collections;

public class MoverTexturaAgua : MonoBehaviour {

    private float desplazaX = 0;
    private float desplazaY = 0;

	void FixedUpdate () {
        desplazaX += 0.02f;
        desplazaY += 0.01f;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Mathf.Cos(desplazaX), Mathf.Sin(desplazaY) / 4);
	}
}
