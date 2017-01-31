using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class SummaryLevel : MonoBehaviour {

    Image firstStar;
    Image secondStar;
    Image thirdStar;

    public Text score;
    private Text levelName;
    private Text rankingList;

    private int con;

    // Use this for initialization
    void Start ()
    {
        con = 0;
        score = transform.FindChild("ScoreSummary").gameObject.GetComponent<Text>();

        levelName = transform.FindChild("LevelName").gameObject.GetComponent<Text>();
        levelName.text = Game.getCurrentLevel().name;

        firstStar = transform.FindChild("FirstStar").gameObject.GetComponent<Image>();
        firstStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        firstStar.color = Color.grey;


        secondStar = transform.FindChild("SecondStar").gameObject.GetComponent<Image>();
        secondStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        secondStar.color = Color.grey;


        thirdStar = transform.FindChild("ThirdStar").gameObject.GetComponent<Image>();
        thirdStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        thirdStar.color = Color.grey;

        if (    Game.getCurrentLevel().index >= Game.getCurrentStadiumLevelQuatity() - 1 )
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = false;
        }

        else
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = true;
        }

        rankingList = transform.FindChild("RankingList").gameObject.GetComponent<Text>();
    }

    public void enableCanvas()
    {
        InvokeRepeating("cont", 1.5f, 0.01f);

        if (Game.getCurrentLevel().index + 1 <= Game.getCurrentStadiumLevelQuatity() - 1 &&
            Game.getCurrentStadium().levels[Game.getCurrentLevel().index + 1].minStarsToUnlock > SaveLoad.savegame.starsAchieved)
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = false;
        }
        
        GetComponent<Canvas>().enabled = true;

        // cargar listado de puntuaciones

        List<int> scores = SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].scores;
        

        rankingList.text = "";
        for (int i = 0; i < scores.Count; i++)
        {
            if (i != 0)
            {
                rankingList.text += "\r\n"; // Salto de linea
            }
            string posicion = (i + 1).ToString();
            rankingList.text += posicion + "-\t\t" + scores[i];
        }

        //cargar las estrellas cogidas.
        StartCoroutine(showStar1(0.5f));
        StartCoroutine(showStar2(1.0f));
        StartCoroutine(showStar3(1.5f));

    }

    public void goWorldMap()
    {
        Game.resetAllValues();
        GameObject go2 = GameObject.Find("MusicaTutorial");
        Destroy(go2);
        GameObject go3 = GameObject.Find("MusicaFutbol");
        Destroy(go3);
        SceneManager.LoadScene("WorldMap");
    }
    public void nextLevel()
    {
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            Component estrella1 = star.GetComponent<EstrellaUno>();
            Component estrella2 = star.GetComponent<EstrellaDos>();
            Component estrella3 = star.GetComponent<EstrellaTres>();

            if (estrella1 != null)
            {
                estrella1.GetComponent<EstrellaUno>().check = false;
            }
            if (estrella2 != null)
            {
                estrella2.GetComponent<EstrellaDos>().check = false;
            }
            if (estrella3 != null)
            {
                estrella3.GetComponent<EstrellaTres>().check = false;
            }
        }

        Game.resetAllValues();

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

    public void restartLevel()
    {
        foreach (GameObject star in GameObject.FindGameObjectsWithTag("Star"))
        {
            Component estrella1 = star.GetComponent<EstrellaUno>();
            Component estrella2 = star.GetComponent<EstrellaDos>();
            Component estrella3 = star.GetComponent<EstrellaTres>();

            if (estrella1 != null)
            {
                estrella1.GetComponent<EstrellaUno>().check = false;
            }
            if (estrella2 != null)
            {
                estrella2.GetComponent<EstrellaDos>().check = false;
            }
            if (estrella3 != null)
            {
                estrella3.GetComponent<EstrellaTres>().check = false;
            }
        }

        Game.resetAllValues();

        Game.setCurrentLevel(Game.getCurrentLevel());

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    IEnumerator showStar1(float s)
    {

        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].firstStarAchieved)
        {
            firstStar.color = Color.white;
        }
    }
    IEnumerator showStar2(float s)
    {

        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].secondStarAchieved)
        {
            secondStar.color = Color.white;
        }
    }
    IEnumerator showStar3(float s)
    {

        yield return new WaitForSeconds(s);

        if (SaveLoad.savegame.stadiumsSavedData[Game.getCurrentStadium().index].levelSavedData[Game.getCurrentLevel().index].thirdStarAchieved)
        {
            thirdStar.color = Color.white;
        }
    }

    void cont()
    {
        if (con <= Game.getScore())
        {
            score.text = "score: " + con;
            con += Game.getScore() * 5 / 1000;
        } else
        {
            con = Game.getScore();
        }
    }
}
