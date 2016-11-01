using UnityEngine;
using System.Collections;

public class RotarPlataformaRotatoria : MonoBehaviour {
    
    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.Rotate(new Vector3(0f,0f,90f));
        }
    }
}
