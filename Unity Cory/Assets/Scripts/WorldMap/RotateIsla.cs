using UnityEngine;
using System.Collections;

public class RotateIsla : MonoBehaviour
{

    public Canvas levelSelector;

    float ang = 0.1f;

    float onda = 0.01f;
    float posYIni;

    float scaleIni = 7f;
    float scaleFin = 8f;
    
    void Start()
    {
        posYIni = transform.position.y;
        scaleIni = transform.localScale.x;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), ang);

        transform.position = new Vector3(transform.position.x, posYIni + Mathf.Sin(onda) * 20, transform.position.z);

        onda += 0.01f;


    }

    void OnMouseEnter()
    {
        if (!levelSelector.GetComponent<LevelSelector>().getVisible()) { 
            transform.localScale = new Vector3(scaleIni + 1f, scaleIni + 1f, scaleIni + 1f);
        }
    }

    void OnMouseExit()
    {
        if (!levelSelector.GetComponent<LevelSelector>().getVisible())
        {
            transform.localScale = new Vector3(scaleIni, scaleIni, scaleIni);   

        }

    }
}
