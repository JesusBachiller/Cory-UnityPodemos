using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public GameObject camButtons;
    public GameObject player;
    private Camera camera;
    private Vector3 offset;
    private Vector3 mousePosition;
    private Vector2 gameWindowResolution;
    private float responsiveMousePercentage;
    private float speedFreeCamera;

    private bool movingRight = false;
    private bool movingDown = false;
    private bool movingLeft = false;
    private bool movingUp = false;

    private int maxFOV;
    private int minFOV;
    
    private int maxXDisplacement;

    // Use this for initialization
    void Start () {

        camera = this.GetComponent<Camera>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 0)
        {
            player = players[0];
            

            offset = transform.position - player.transform.position;

        }
        

        maxFOV = 60;
        minFOV = 30;
        maxXDisplacement = findMaxXDisplacement();

        camButtons.GetComponent<Canvas>().enabled = false;

        mousePosition = Input.mousePosition;
        Game.cameraFollowsPlayer = true;
        responsiveMousePercentage = 0.05f;
        speedFreeCamera = 10.0f;
    }

    int findMaxXDisplacement()
    {
        
        int maxX = 0;
        for (int i = 0; i < Game.getCurrentLevel().mapElements.Count; i++)
        {
            if (maxX < Game.getCurrentLevel().mapElements[i].Count - 1)
            {
                maxX = Game.getCurrentLevel().mapElements[i].Count - 1;
            }
        }
        return maxX;
    }


    void LateUpdate()
    {
        if (movingRight) { moveRight(); }
        if (movingLeft) { moveLeft(); }
        if (movingDown) { moveDown(); }
        if (movingUp) { moveUp(); }

        if (Input.GetKeyDown(KeyCode.Space) && !Game.getCoryFly() && !Game.getCoryDie() && !Game.getCoryEnd()) //Free Camera
        {
            if (Game.cameraFollowsPlayer) {
                Game.cameraFollowsPlayer = false;
                camButtons.GetComponent<Canvas>().enabled = true;
            } else {
                Game.cameraFollowsPlayer = true;
                camButtons.GetComponent<Canvas>().enabled = false;
            }
        }
        
        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            if (camera.fieldOfView > minFOV)
            {
                camera.fieldOfView--;
            }
        }
        else if (d < 0f)
        {
            if(camera.fieldOfView < maxFOV)
            {
                camera.fieldOfView++;
            }
        }

        if (Game.cameraFollowsPlayer)
        {
            camaraPlana();
            //camaraAerea();
        }

        if (Game.getCoryFly())
        {
            Game.cameraFollowsPlayer = true;
            camButtons.GetComponent<Canvas>().enabled = false;
        }
        if (Game.getCoryDie())
        {
            Game.cameraFollowsPlayer = false;
            camButtons.GetComponent<Canvas>().enabled = false;
        }
        if (Game.getCoryEnd())
        {
            Game.cameraFollowsPlayer = false;
            camButtons.GetComponent<Canvas>().enabled = false;
        }

    }

    private void camaraPlana()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, 10, transform.position.z);
            float maxYCory = 30;
            float maxCamFOV = 70;
            float initialFOV = 52;
            float cameraFOV;

            if (player.transform.position.y > maxYCory)
            {
                transform.LookAt(new Vector3(player.transform.position.x + 10, (player.transform.position.y) + 7, 0));

                cameraFOV = player.transform.position.y * initialFOV;
                if (cameraFOV >= maxCamFOV)
                {
                    cameraFOV = maxCamFOV;
                }
            }
            else
            {
                float porcentaje = (Mathf.Pow(player.transform.position.y, 2) * 1) / Mathf.Pow(maxYCory, 2);

                transform.LookAt(new Vector3(player.transform.position.x + 10, (player.transform.position.y * porcentaje) + 7, 0));

                cameraFOV = player.transform.position.y * porcentaje + initialFOV;
                if (cameraFOV >= maxCamFOV)
                {
                    cameraFOV = maxCamFOV;
                }
            }
            camera.fieldOfView = cameraFOV;
        }
    }

    private void camaraAerea()
    {
        if (player != null)
        {
            float maxYCory = 30;
            float maxCamFOV = 57;
            float initialFOV = 55;
            float cameraFOV;

            float incrementoYPosicion = 5;

            float maxDecrementoLookAtY = 15;
            float minDecrementoLookAtY = 0;



            if (player.transform.position.y > maxYCory + incrementoYPosicion)
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y + incrementoYPosicion + 12, transform.position.z);

                transform.LookAt(new Vector3(player.transform.position.x + 10, (player.transform.position.y + incrementoYPosicion) - maxDecrementoLookAtY, 0));

                cameraFOV = player.transform.position.y * initialFOV;
                if (cameraFOV >= maxCamFOV)
                {
                    cameraFOV = maxCamFOV;
                }
            }
            else
            {
                float porcentajePosicion = (Mathf.Pow(player.transform.position.y, 1.2f) * 1) / Mathf.Pow(maxYCory + incrementoYPosicion, 1.2f);
                float porcentajeRotacion = (Mathf.Pow(player.transform.position.y, 1.05f) * 1) / Mathf.Pow(maxYCory + incrementoYPosicion, 1.05f);
                float porcentajeFOV = (Mathf.Pow(player.transform.position.y, 2f) * 1) / Mathf.Pow(maxYCory + incrementoYPosicion, 2f);

                transform.position = new Vector3(player.transform.position.x, (player.transform.position.y + incrementoYPosicion) * porcentajePosicion + 12, transform.position.z);

                float decrementoLookAtY = minDecrementoLookAtY + (porcentajeRotacion * (maxDecrementoLookAtY - minDecrementoLookAtY));
                transform.LookAt(new Vector3(player.transform.position.x + 10, (player.transform.position.y + incrementoYPosicion) - decrementoLookAtY, 0));

                cameraFOV = player.transform.position.y * porcentajeFOV + initialFOV;
                if (cameraFOV >= maxCamFOV)
                {
                    cameraFOV = maxCamFOV;
                }
            }

            camera.fieldOfView = cameraFOV;
        }
    }

    public static Vector2 GetMainGameViewSize()
    {
        System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
        System.Reflection.MethodInfo GetSizeOfMainGameView = T.GetMethod("GetSizeOfMainGameView", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
        System.Object Res = GetSizeOfMainGameView.Invoke(null, null);
        return (Vector2)Res;
    }

    public void setCameraFollowPlayer(bool b)
    {
        Game.cameraFollowsPlayer = b;
    }

    public void moveRight()
    {
        if (transform.position.x <= maxXDisplacement - 10f)
        {
            transform.position += new Vector3(speedFreeCamera, 0, 0) * Time.deltaTime;
        }
    }

    public void moveLeft()
    {
        if (transform.position.x >= -2.0f)
        {
            transform.position += new Vector3(-speedFreeCamera, 0, 0) * Time.deltaTime;
        }
    } 

    public void moveUp()
    {
        if (transform.position.y <= 16.0f)
        {
            transform.position += new Vector3(0, speedFreeCamera, 0) * Time.deltaTime;
        }
    }

    public void moveDown()
    {
        if (transform.position.y >= 5.0f)
        {
            transform.position += new Vector3(0, -speedFreeCamera, 0) * Time.deltaTime;
        }
    }

    public void enableMovingRight()
    {
        movingRight = true;
    }
    public void enableMovingLeft()
    {
        movingLeft = true;
    }
    public void enableMovingDown()
    {
        movingDown = true;
    }
    public void enableMovingUp()
    {
        movingUp = true;
    }
    public void disableMovingRight()
    {
        movingRight = false;
    }
    public void disableMovingLeft()
    {
        movingLeft = false;
    }
    public void disableMovingDown()
    {
        movingDown = false;
    }
    public void disableMovingUp()
    {
        movingUp = false;
    }

}
