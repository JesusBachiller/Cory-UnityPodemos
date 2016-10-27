using UnityEngine;
using System.Collections;

public class MoveCamRight : MonoBehaviour {

    public GameObject camera;

    void OnMouseDown()
    {
        Debug.Log("entro");
        camera.GetComponent<CameraController>().moveRight();
    }
}
