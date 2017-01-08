using UnityEngine;
using System.Collections;

public class MusicRandom : MonoBehaviour {

    int nivel = 1;

    void Awake()
    {
        GameObject go = GameObject.Find("Musica");
        GameObject go2 = GameObject.Find("MusicRandom");
        GameObject go3 = GameObject.Find("MusicaTutorial");
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Music");
        int longitud = gos.Length;
        if (longitud > 1)
        {
            Debug.Log("entro");
            Destroy(this.gameObject);
        }
        if (nivel == 1)
        {
            if (go == null)
            {
                nivel = 2;
                Debug.Log("Entro Primero");
                int rnd = Random.Range(1, 3);
                Debug.Log(rnd);
                AudioSource audio = gameObject.AddComponent<AudioSource>();
                audio.loop = true;
                if (rnd == 1)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Cinema"));
                }
                if (rnd == 2)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Marty"));
                }
                if (rnd == 3)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Quirky"));
                }
            }
        }
        else
        {
            if (go2 == null)
            {
                Destroy(go3);
                Debug.Log("Entro Despues");
                int rnd = Random.Range(1, 3);
                Debug.Log(rnd);
                AudioSource audio = gameObject.AddComponent<AudioSource>();
                audio.loop = true;
                if (rnd == 1)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Cinema"));
                }
                if (rnd == 2)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Marty"));
                }
                if (rnd == 3)
                {
                    audio.PlayOneShot((AudioClip)Resources.Load("Quirky"));
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
