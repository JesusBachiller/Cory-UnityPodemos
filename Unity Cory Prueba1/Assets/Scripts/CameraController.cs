using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;
    private Vector3 mousePosition;
    private Vector2 gameWindowResolution;
    private float responsiveMousePercentage;
    private bool cameraFollowsPlayer;

    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            player = GameObject.FindGameObjectsWithTag("Player")[0];
            offset = transform.position - player.transform.position;
        }

        mousePosition = Input.mousePosition;
        cameraFollowsPlayer = true;
        responsiveMousePercentage = 0.05f;
    }


    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraFollowsPlayer) { cameraFollowsPlayer = false; } else { cameraFollowsPlayer = true; }
        }

        if (cameraFollowsPlayer)
        {
            if (player != null)
            {
                transform.position = player.transform.position + offset;
            }
        } else
        {
            moveCameraWithMouse();
        }
    }

    private void moveCameraWithMouse()
    {
        mousePosition = Input.mousePosition;
        gameWindowResolution = GetMainGameViewSize();
        float speed = 5;


        if (mousePosition.x <= gameWindowResolution.x * responsiveMousePercentage) // Si toca por la izquierda
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }

        if (mousePosition.x >= gameWindowResolution.x - (gameWindowResolution.x * responsiveMousePercentage)) // Si toca por la derecha
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }

        if (mousePosition.y >= gameWindowResolution.y * responsiveMousePercentage) // Si toca por arriba
        {
            transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        if (mousePosition.y <= gameWindowResolution.y - (gameWindowResolution.y * responsiveMousePercentage)) // Si toca por abajo
        {
            transform.position += new Vector3(0, -speed, 0) * Time.deltaTime;
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
}
