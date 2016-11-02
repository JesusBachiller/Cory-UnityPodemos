using UnityEngine;
using System.Collections;

public class MataCoryEscenario : MonoBehaviour {

    public GameObject cory;
    

    // Update is called once per frame
    void OnCollisionEnter(Collision col)
    {
        if(cory == null)
        {
            cory = GameObject.FindGameObjectWithTag("Player");
        }

        if (col.gameObject.tag == cory.tag && !Game.getCoryEnd())
        {
            Game.setCoryDie(true);
            Game.setCoryFly(false);

            StartCoroutine(changePositionCory(2));

            cory.GetComponent<TrailRenderer>().enabled = false;

            SaveLoad.savegame.timesDied += 1;
            SaveLoad.Save();
        }
    }

    IEnumerator changePositionCory(float s)
    {
        yield return new WaitForSeconds(s);

        cory.GetComponent<Rigidbody>().isKinematic = true;

        Vector3 posInit = cory.GetComponent<lanzamiento>().getPosInitCory();
        cory.transform.position = posInit;
        cory.transform.rotation = Quaternion.Euler(new Vector3(0, 45, 120));
        
        cory.GetComponent<TrailRenderer>().enabled = true;
        cory.GetComponent<Rigidbody>().isKinematic = false;
        Game.setCoryDie(false);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().setCameraFollowPlayer(true);

    }
}
