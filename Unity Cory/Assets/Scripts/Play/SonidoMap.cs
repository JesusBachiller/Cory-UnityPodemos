using UnityEngine;
using System.Collections;

public class SonidoMap : MonoBehaviour
{
    void Awake()
    {
        GameObject go = GameObject.Find("Musica");
        Destroy(go);
        GameObject go2 = GameObject.Find("MusicRandom");
        Destroy(go2);
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Music");
        int longitud = gos.Length;
        if (longitud > 1)
        {
            Debug.Log(longitud);
            Debug.Log(gos[0]);
            Debug.Log(gos[1]);

            Destroy(this.gameObject);
        }
        else DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}