using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public GameObject camButtons;
    private GameObject player;
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

    // Use this for initialization
    void Start () {

        camera = this.GetComponent<Camera>();

        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            

            offset = transform.position - player.transform.position;

        }

        maxFOV = 50;
        minFOV = 30;

        camButtons.GetComponent<Canvas>().enabled = false;

        mousePosition = Input.mousePosition;
        Game.cameraFollowsPlayer = true;
        responsiveMousePercentage = 0.05f;
        speedFreeCamera = 10.0f;
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
            if (player != null)
            {
                transform.position = player.transform.position + offset;
            }
        } else
        {
            if (!Game.getCoryDie())
            {
                //moveCameraWithMouse();
            }
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
        if (transform.position.x <= 30.0f)
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
