using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SummaryLevel : MonoBehaviour {

    Image firstStar;
    Image secondStar;
    Image thirdStar;

    // Use this for initialization
    void Start () {

        firstStar = transform.FindChild("FirstStar").gameObject.GetComponent<Image>();
        firstStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        firstStar.color = Color.grey;


        secondStar = transform.FindChild("SecondStar").gameObject.GetComponent<Image>();
        secondStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        secondStar.color = Color.grey;


        thirdStar = transform.FindChild("ThirdStar").gameObject.GetComponent<Image>();
        thirdStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
        thirdStar.color = Color.grey;

        Debug.Log(Game.getCurrentStadium().levels[Game.getCurrentLevel().index + 1].minStarsToUnlock);
        Debug.Log(SaveLoad.savegame.starsAchieved);

        if (    Game.getCurrentLevel().index >= Game.getCurrentStadiumLevelQuatity() - 1 )
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = false;
        }

        else
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = true;
        } 
    }

    public void enableCanvas()
    {
        if (Game.getCurrentLevel().index + 1 <= Game.getCurrentStadiumLevelQuatity() - 1 &&
            Game.getCurrentStadium().levels[Game.getCurrentLevel().index + 1].minStarsToUnlock > SaveLoad.savegame.starsAchieved)
        {
            transform.FindChild("NextLevel").gameObject.GetComponent<Button>().interactable = false;
        }
        
        GetComponent<Canvas>().enabled = true;

        //cargar las estrellas cogidas.
        StartCoroutine(showStar1(0.5f));
        StartCoroutine(showStar2(1.0f));
        StartCoroutine(showStar3(1.5f));

    }

    public void goWorldMap()
    {
        Game.resetAllValues();
        SceneManager.LoadScene("WorldMap");
    }
    public void nextLevel()
    {

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

    IEnumerator showStar1(float s)
    {

        yield return new WaitForSeconds(s);

        if (Game.getFirstStarOfLevelAchieved())
        {
            firstStar.color = Color.white;
        }
    }
    IEnumerator showStar2(float s)
    {

        yield return new WaitForSeconds(s);

        if (Game.getSecondStarOfLevelAchieved())
        {
            secondStar.color = Color.white;
        }
    }
    IEnumerator showStar3(float s)
    {

        yield return new WaitForSeconds(s);

        if (Game.getThirdStarOfLevelAchieved())
        {
            thirdStar.color = Color.white;
        }
    }
}
