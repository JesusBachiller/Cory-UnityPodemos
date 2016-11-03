using UnityEngine;
using System.Collections;

public class EstrellaTres : MonoBehaviour
{

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
    }

    void checkIfAchieved()
    {

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved)
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.cyan;
            }
        }
        else
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.red;
            }
        }
    }

    IEnumerator waitAndCheckIfAchieved(float s)
    {
        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved)
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.cyan;
            }
        }
        else
        {
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.red;
            }
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!Game.getCoryDie())
            {
                foreach (Material m in GetComponent<Renderer>().materials)
                {
                    m.color = Color.white;
                }

                Game.setThirdStarOfLevelAchieved(true);
            }

        }
    }

}
