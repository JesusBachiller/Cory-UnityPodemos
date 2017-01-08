using UnityEngine;
using System.Collections;

public class ChangeIceState : MonoBehaviour
{
    public GameObject particleIce;

    private GameObject myParticleF;

    private GameObject[] Fire_cubs;

    public GameObject[] PS;

    private float disappearEffectSec;

    // Use this for initialization
    void Start()
    {

        disappearEffectSec = 4f;

        Fire_cubs = GameObject.FindGameObjectsWithTag("Fuego");
    }


    void OnTriggerEnter(Collider other)
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.PlayOneShot((AudioClip)Resources.Load("hielo1"));
        if (other.gameObject.tag == "Player")
        {
            if (Game.getCoryState() == "fire")
            {
                GameObject PS = GameObject.FindGameObjectWithTag("ParticleFire");

                Destroy(PS);
                foreach (GameObject i in GameObject.FindGameObjectsWithTag("Hielo"))
                {
                    i.GetComponent<BoxCollider>().enabled = true;
                }
            }
            if (Game.getCoryState() == "ice")
            {
                GameObject PS = GameObject.FindGameObjectWithTag("ParticleIce");

                Destroy(PS);

                
            }

            Game.setCoryState("ice");

            Material[] M = other.gameObject.GetComponent<MeshRenderer>().materials;
            M[0].color = Color.Lerp(Color.white, Color.blue, 0.6f);
            M[1].color = Color.Lerp(Color.white, Color.blue, 0.6f);
            M[2].color = Color.Lerp(Color.white, Color.blue, 0.6f);
            M[3].color = Color.Lerp(Color.white, Color.blue, 0.6f);
            M[4].color = Color.Lerp(Color.white, Color.blue, 0.6f);

            foreach (GameObject h in Fire_cubs)
            {
                h.GetComponent<BoxCollider>().enabled = false;
            }

            myParticleF = Instantiate(particleIce, other.gameObject.transform.position, Quaternion.identity) as GameObject;

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

            foreach (GameObject h in Fire_cubs)
            {
                h.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }
}
