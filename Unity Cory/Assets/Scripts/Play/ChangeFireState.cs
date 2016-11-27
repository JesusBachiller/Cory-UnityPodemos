using UnityEngine;
using System.Collections;

public class ChangeFireState : MonoBehaviour
{
    public GameObject particleFire;
    private GameObject myParticleF;

    private GameObject[] hielo_cubs;

    public GameObject[] PS;

    private float disappearEffectSec;

    // Use this for initialization
    void Start()
    {
        disappearEffectSec = 4f;

        hielo_cubs = GameObject.FindGameObjectsWithTag("Hielo");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Game.getCoryState() == "fire")
            {
                GameObject PS = GameObject.FindGameObjectWithTag("ParticleFire");

                Destroy(PS);
            }
            if (Game.getCoryState() == "ice")
            {
                GameObject PS = GameObject.FindGameObjectWithTag("ParticleIce");

                Destroy(PS);
            }
            Game.setCoryState("fire");

            Material[] M = other.gameObject.GetComponent<MeshRenderer>().materials;
            M[0].color = Color.Lerp(Color.white, Color.red, 0.6f);
            M[1].color = Color.Lerp(Color.white, Color.red, 0.6f);
            M[2].color = Color.Lerp(Color.white, Color.red, 0.6f);
            M[3].color = Color.Lerp(Color.white, Color.red, 0.6f);
            M[4].color = Color.Lerp(Color.white, Color.red, 0.6f);

            foreach (GameObject h in hielo_cubs)
            {
                h.GetComponent<BoxCollider>().enabled = false;
            }

            myParticleF = Instantiate(particleFire, other.gameObject.transform.position, Quaternion.identity) as GameObject;


            Destroy(myParticleF, disappearEffectSec + 1);

            StartCoroutine(disappearEffect(disappearEffectSec, other.gameObject, myParticleF));
        }
    }

    IEnumerator disappearEffect(float s, GameObject GO, GameObject PF)
    {

        yield return new WaitForSeconds(s);

        if (myParticleF != null)
        {
            PF.GetComponent<ParticleSystem>().Stop();
            PF.GetComponent<ParticleSystemFollowCory>().setIsStopped(true);

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