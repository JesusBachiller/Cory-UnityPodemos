﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

    private GameObject cory;

    // Use this for initialization
    void Start()
    {
        cory = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == cory.tag && !Game.getCoryDie())
        {
            StartCoroutine(reloadScene(2));
            
        }
    }

    IEnumerator reloadScene(float s)
    {

        yield return new WaitForSeconds(s);


        if (Game.getCurrentLevel().index == Game.getStadiumLevels().Count - 1)
        {
            Game.setCurrentLevel(null);
            SceneManager.LoadScene("WorldMap");
        }
        else
        {
            foreach (Level level in Game.getStadiumLevels())
            {
                if (level.index - 1 == Game.getCurrentLevel().index)
                {
                    Game.setCurrentLevel(level);
                    break;
                }
            }
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


        Game.resetAllValues();


    }
}