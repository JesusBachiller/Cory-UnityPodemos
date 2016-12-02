﻿using UnityEngine;
using System.Collections;

public class EstrellaDos : MonoBehaviour
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
        if (!Game.getCoryFly())
        {
            checkIfAchieved();
        }
    }

    void checkIfAchieved()
    {

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].secondStarAchieved)
        {
            Game.setSecondStarOfLevelAchieved(true);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
        }
        else
        {
            Game.setSecondStarOfLevelAchieved(false);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
        }
    }

    IEnumerator waitAndCheckIfAchieved(float s)
    {
        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].secondStarAchieved)
        {
            Game.setSecondStarOfLevelAchieved(true);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = new Color32(204, 153, 0, 1); // naranja
            }
        }
        else
        {
            Game.setSecondStarOfLevelAchieved(false);
            foreach (Material m in GetComponent<Renderer>().materials)
            {
                m.color = Color.white;
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!Game.getCoryDie() || !Game.getCoryEnd())
            {
                Game.setSecondStarOfLevelAchieved(true);
                foreach (Material m in GetComponent<Renderer>().materials)
                {
                    m.color = Color.yellow;
                }
            }

            GameObject padre = transform.parent.gameObject;
            padre.GetComponentInChildren<ParticleSystem>().Play();
        }
    }

}
