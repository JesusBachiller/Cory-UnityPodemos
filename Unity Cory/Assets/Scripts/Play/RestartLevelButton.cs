using UnityEngine;
using System.Collections;

public class RestartLevelButton : MonoBehaviour {

	public void RestartLevel()
    {
        //Debug.Log(!(Game.getCoryDie() || Game.getCoryEnd()));
        if (!(Game.getCoryDie() || Game.getCoryEnd()))
        {
            GameObject cory = GameObject.FindGameObjectWithTag("Player");

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
