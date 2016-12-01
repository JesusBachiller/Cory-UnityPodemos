using UnityEngine;
using System.Collections;

public class EstrellaUno : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        checkIfAchieved();
    }

    void Update()
    {
        if (Game.getCoryDie())
        {
            StartCoroutine(waitAndCheckIfAchieved(2f));
        }
        if (!Game.getCoryFly())
        {
            checkIfAchieved();
        }
    }

    void checkIfAchieved()
    {
        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].firstStarAchieved)
        {
            Game.setFirstStarOfLevelAchieved(true);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
        }
        else
        {
            Game.setFirstStarOfLevelAchieved(false);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
        }
    }

    IEnumerator waitAndCheckIfAchieved(float s)
    {
        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].firstStarAchieved)
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
            Game.setFirstStarOfLevelAchieved(true);
        }
        else
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
            Game.setFirstStarOfLevelAchieved(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!Game.getCoryDie() || !Game.getCoryEnd())
            {
                foreach (Material m in GetComponent<Renderer>().materials)
                {
                    m.color = Color.yellow;
                }
                Game.setFirstStarOfLevelAchieved(true);
            }
        }
    }

}
