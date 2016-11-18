using UnityEngine;
using System.Collections;

public class RotarPlataformaRotatoria : MonoBehaviour {

    public int index;

    public GameObject CentroPR;

    void Start()
    {
        index = 0;
        CentroPR = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("AAAA");
            OnRightClick();
            if (CentroPR != null)
            {
                CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_init = Input.mousePosition;
            }
        }
        else
        {
            if (CentroPR != null)
            {
                if (Input.GetMouseButton(1))
                {
                    CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_end = Input.mousePosition;
                }
                else
                {
                    if (CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_init != Vector3.zero && CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_end != Vector3.zero)
                    {
                        reseltValues();
                    }
                }
            }
            
        }

        if (CentroPR != null)
        {
            if (CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_init != Vector3.zero && CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_end != Vector3.zero)
            {
                CentroPR.GetComponentInParent<PlataformaRotatoria>().rotatePlataform();
            }
        }
    }

    // Check for Right-Click
    void OnRightClick()
    {
        if (!(Game.getCoryFly() || Game.getCoryDie()) ) {
            // Cast a ray from the mouse
            // cursors position
            Ray clickPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitPoint;

            // See if the ray collided with an object
            if (Physics.Raycast(clickPoint, out hitPoint))
            {
                // Make sure this object was the
                // one that received the right-click
                if (hitPoint.collider == this.GetComponent<Collider>())
                {
                    // Put code for the right click event
                    //Debug.Log("Right Clicked on " + this.name);
                    CentroPR = this.gameObject;
                }
            }
        }
    }
    

    private void reseltValues()
    {

        CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_init = Vector3.zero;
        CentroPR.GetComponentInParent<PlataformaRotatoria>().poss_end = Vector3.zero;

        CentroPR.GetComponentInParent<PlataformaRotatoria>().v_Init_End = Vector3.zero;


        CentroPR.GetComponentInParent<PlataformaRotatoria>().rad = 0;
        CentroPR.GetComponentInParent<PlataformaRotatoria>().degrees = 0;

        CentroPR = null;
    }
}
