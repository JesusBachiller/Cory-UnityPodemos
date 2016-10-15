using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Camera camera;
    private Vector3 offset;
    private Vector3 mousePosition;
    private Vector2 gameWindowResolution;
    private float responsiveMousePercentage;
    private bool cameraFollowsPlayer;
    private float speedFreeCamera;

    private int maxFOV;
    private int minFOV;

    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];

            GameObject c = GameObject.FindGameObjectsWithTag("MainCamera")[0];
            camera = c.GetComponent<Camera>();

            offset = transform.position - player.transform.position;

            maxFOV = 50;
            minFOV = 30;
        }

        mousePosition = Input.mousePosition;
        cameraFollowsPlayer = true;
        responsiveMousePercentage = 0.05f;
        speedFreeCamera = 5.0f;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Free Camera
        {
            if (cameraFollowsPlayer) { cameraFollowsPlayer = false; } else { cameraFollowsPlayer = true; }
        }

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f)
        {
            if(camera.fieldOfView > minFOV)
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

        if (cameraFollowsPlayer)
        {
            if (player != null)
            {
                transform.position = player.transform.position + offset;
            }
        } else
        {
            if (!Game.coryDie)
            {
                moveCameraWithMouse();
            }
        }

        if (Game.coryFly)
        {
            cameraFollowsPlayer = true;
        }
        if (Game.coryDie)
        {
            cameraFollowsPlayer = false;
        }

    }

    private void moveCameraWithMouse()
    {
        mousePosition = Input.mousePosition;
        gameWindowResolution = GetMainGameViewSize();


        if (mousePosition.x <= gameWindowResolution.x * responsiveMousePercentage && transform.position.x >= 7.0f) // Si toca por la izquierda
        {
            transform.position += new Vector3(-speedFreeCamera, 0, 0) * Time.deltaTime;
        }

        if (mousePosition.x >= gameWindowResolution.x - (gameWindowResolution.x * responsiveMousePercentage) && transform.position.x <= 55.0f) // Si toca por la derecha
        {
            transform.position += new Vector3(speedFreeCamera, 0, 0) * Time.deltaTime;
        }

        if (mousePosition.y >= gameWindowResolution.y * responsiveMousePercentage && transform.position.y <= 16.0f) // Si toca por arriba
        {
            transform.position += new Vector3(0, speedFreeCamera, 0) * Time.deltaTime;
        }

        if (mousePosition.y <= gameWindowResolution.y - (gameWindowResolution.y * responsiveMousePercentage) && transform.position.y >= 9.0f) // Si toca por abajo
        {
            transform.position += new Vector3(0, -speedFreeCamera, 0) * Time.deltaTime;
        }
        //Debug.Log(transform.position);
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
        cameraFollowsPlayer = b;
    }
}
