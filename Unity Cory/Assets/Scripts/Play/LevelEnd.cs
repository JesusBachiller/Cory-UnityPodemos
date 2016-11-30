﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    private GameObject cory;

    public GameObject summary;

    // Use this for initialization
    void Start()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
        summary = GameObject.Find("SummaryLevel");
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == cory.tag && !Game.getCoryDie())
        {
            StartCoroutine(reloadScene(2));
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].firstStarAchieved = Game.getFirstStarOfLevelAchieved();
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].secondStarAchieved = Game.getSecondStarOfLevelAchieved();
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved = Game.getThirdStarOfLevelAchieved();
            SaveLoad.Save();
        }
    }

    IEnumerator reloadScene(float s)
    {

        yield return new WaitForSeconds(s);

        summary.GetComponent<SummaryLevel>().enableCanvas();

    }
}
