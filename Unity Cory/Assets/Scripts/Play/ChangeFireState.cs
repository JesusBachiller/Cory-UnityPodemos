using UnityEngine;
using System.Collections;

public class ChangeFireState : MonoBehaviour {

    private GameObject Cory;
    public GameObject particleFire;

    private GameObject[] hielo_cubs;

    public GameObject[] PS;

    private float disappearEffectSec;

	// Use this for initialization
	void Start () {
        Cory = GameObject.FindGameObjectWithTag("Player");

        disappearEffectSec = 4f;

        hielo_cubs = GameObject.FindGameObjectsWithTag("Hielo");
	}
    

    void OnTriggerEnter(Collider other)
    {
        //Esto solo sirve para solo 1 herramienta de cambio a fuego
        Game.setCoryState("fire");

        Material[] M = Cory.GetComponent<MeshRenderer>().materials;
        M[0].color = Color.Lerp(Color.white, Color.red, 0.6f);
        M[1].color = Color.Lerp(Color.white, Color.red, 0.6f);
        M[2].color = Color.Lerp(Color.white, Color.red, 0.6f);
        M[3].color = Color.Lerp(Color.white, Color.red, 0.6f);
        M[4].color = Color.Lerp(Color.white, Color.red, 0.6f);

        foreach (GameObject h in hielo_cubs)
        {
            h.GetComponent<BoxCollider>().enabled = false;
        }

        GameObject ParticleF = Instantiate(particleFire, other.gameObject.transform.position, Quaternion.identity) as GameObject;

        Destroy(ParticleF, disappearEffectSec + 1);

        StartCoroutine(disappearEffect(disappearEffectSec, other.gameObject, ParticleF));
    }
    
    IEnumerator disappearEffect(float s, GameObject GO, GameObject PF)
    {

        yield return new WaitForSeconds(s);
        
        PF.GetComponent<ParticleSystem>().Stop();
        PF.GetComponent<ParticleSystemFollowCory>().setIsStopped(true);

        PS = GameObject.FindGameObjectsWithTag("ParticleFire");
        bool allStopped = true;

        foreach(GameObject part in PS)
        {
            if (!part.GetComponent<ParticleSystemFollowCory>().getIsStopped())
            {
                allStopped = false;
                break;
            }
        }

        if (allStopped)
        {
            Game.setCoryState("noState");

            Material[] M = GO.GetComponent<MeshRenderer>().materials;
            M[0].color = Color.white;
            M[1].color = Color.white;
            M[2].color = Color.white;
            M[3].color = Color.white;
            M[4].color = Color.white;

            foreach (GameObject h in hielo_cubs)
            {
                h.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
