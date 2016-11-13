using UnityEngine;
using System.Collections;

public class RestartLevelButton : MonoBehaviour
{

    public void RestartLevel()
    {
        if (!(Game.getCoryDie() || Game.getCoryEnd()))
        {
            Game.setCoryState("noState");

            foreach (GameObject PS in GameObject.FindGameObjectsWithTag("ParticleFire"))
            {
                PS.GetComponent<ParticleSystem>().Stop();
                PS.GetComponent<ParticleSystemFollowCory>().setIsStopped(true);
            }

            GameObject cory = GameObject.FindGameObjectWithTag("Player");

            Material[] M = cory.GetComponent<MeshRenderer>().materials;
            M[0].color = Color.white;
            M[1].color = Color.white;
            M[2].color = Color.white;
            M[3].color = Color.white;
            M[4].color = Color.white;


            foreach (GameObject h in GameObject.FindGameObjectsWithTag("Hielo"))
            {
                h.GetComponent<BoxCollider>().enabled = true;
            }

            Game.setCoryDie(true);
            Game.setCoryFly(false);

            cory.GetComponent<Rigidbody>().isKinematic = true;

            Vector3 posInit = cory.GetComponent<lanzamiento>().getPosInitCory();
            cory.transform.position = posInit;
            cory.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 120));

            cory.GetComponent<TrailRenderer>().Clear();
            cory.GetComponent<Rigidbody>().isKinematic = false;
            Game.setCoryDie(false);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().setCameraFollowPlayer(true);
        }
    }
}
