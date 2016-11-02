using UnityEngine;
using System.Collections;

public class PlataformaRotatoria : MonoBehaviour {
    
    public int index;

    public Vector3 poss_init;
    public Vector3 poss_end;

    public Vector3 v_Init_End;
    
    public float rad;
    public float degrees;

    // Use this for initialization
    void Start () {

        poss_init = Vector3.zero;
        poss_end = Vector3.zero;

        v_Init_End = Vector3.zero;

        rad = 0f;
        degrees = 0f;
        
    }

    public void rotatePlataform()
    {
        if (poss_init != Vector3.zero && poss_end != Vector3.zero)
        {
            v_Init_End = new Vector3(poss_end.x - poss_init.x, poss_end.y - poss_init.y, poss_end.z - poss_init.z);
            if (v_Init_End.y != 0)
            {
                rad = Mathf.Atan(v_Init_End.x / v_Init_End.y);
                //Debug.Log("Radianes: " + rad);
                degrees = rad * 180f / Mathf.PI;
                //Debug.Log("grados: " + degrees);

                transform.eulerAngles = new Vector3(0f, 0f, -degrees);

                Debug.Log(transform.eulerAngles);
            }

        }
        
    }
}
