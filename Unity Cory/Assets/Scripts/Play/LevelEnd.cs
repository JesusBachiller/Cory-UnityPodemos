using UnityEngine;
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
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].firstStarAchieved = Game.getFirstStarOfLevelAchieved();
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].secondStarAchieved = Game.getSecondStarOfLevelAchieved();
            SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved = Game.getThirdStarOfLevelAchieved();
            SaveLoad.Save();
        }
    }

    IEnumerator reloadScene(float s)
    {

        yield return new WaitForSeconds(s);


        Game.resetAllValues();

        if (Game.getCurrentLevel().index >= Game.getCurrentStadiumLevelQuatity() - 1)
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




    }
}
