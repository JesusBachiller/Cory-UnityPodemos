using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorldMapStadium : MonoBehaviour {
    
    public int stadiumNumber;
    public Canvas levelSelector;
    private Stadium stadium;
    private List<Level> stadiumLevels;

    private List<GameObject> levelBoxes;

	// Use this for initialization
	void Start ()
    {
        levelSelector = levelSelector.GetComponent<Canvas>();
        levelSelector.enabled = false;


        // Molaria uni todo esto en una funcion de (por ejemplo) una clase "Xml" o "Util"
        StadiumContainer sc = StadiumContainer.Load();
        if(stadiumNumber <= sc.stadiums.Count - 1) // Check object number to avoid out of range exception
        {
            stadium = sc.stadiums[stadiumNumber];
            string stadiumLevelsPath = stadium.xmlLevelsPath;
            LevelContainer lc = LevelContainer.Load(stadiumLevelsPath);
            stadiumLevels = lc.levels;
        }
        // Fin de --> Molaria uni todo esto en una funcion de (por ejemplo) una clase "Xml" o "Util"

        levelBoxes = new List<GameObject>();
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level1").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level2").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level3").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level4").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level5").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level6").gameObject);
        foreach(GameObject levelBox in levelBoxes)
        {
            levelBox.GetComponent<Canvas>().enabled = false;
        }
    }

    public void changeScene(string sceneName, Level actualLevel, List<Level> SL)
    {
        Game.setStadiumLevels(stadiumLevels);
        Game.setCurrentLevel(actualLevel);
        SceneManager.LoadScene(sceneName);
    }

    public void OnMouseDown()
    {
        // Instantiate Canvas
        levelSelector.enabled = true;

        // Change title of stadium
        Text stadiumName = levelSelector.transform.Find("BackgroundLevelSelector").FindChild("StadiumName").gameObject.GetComponent<Text>();
        stadiumName.text = stadium.name;


        //GameObject levelBox = levelSelector.transform.Find("BackgroundLevelSelector").FindChild("LevelBox").gameObject;
        int levelNumber = 0;
        foreach (Level level in stadiumLevels)
        {
            GameObject currentLevelBox = levelBoxes[levelNumber];
            if (levelNumber <= levelBoxes.Count - 1)
            {
                currentLevelBox.GetComponent<Canvas>().enabled = true;
                string sceneName = stadium.sceneName;
                Level actualLevel = level;
                currentLevelBox.GetComponent<Button>().onClick.AddListener(() => changeScene(sceneName, actualLevel, stadiumLevels));

                Image levelPreviewImage = currentLevelBox.transform.FindChild("LevelImage").gameObject.GetComponent<Image>();
                levelPreviewImage.sprite = Resources.Load<Sprite>("LevelPreviewImages/" + level.previewImagePath) as Sprite;

                // Load from Savegame how many Stars has the player achieved
                Image firstStar = currentLevelBox.transform.FindChild("FirstStar").gameObject.GetComponent<Image>();
                if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].firstStarAchieved)
                {
                    firstStar.color = Color.red;
                }
                Image secondStar = currentLevelBox.transform.FindChild("SecondStar").gameObject.GetComponent<Image>();
                if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].secondStarAchieved)
                {
                    secondStar.color = Color.red;
                }
                Image thirdStar = currentLevelBox.transform.FindChild("ThirdStar").gameObject.GetComponent<Image>();
                if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].thirdStarAchieved)
                {
                    thirdStar.color = Color.red;
                }

                Text levelName = currentLevelBox.transform.FindChild("LevelName").gameObject.GetComponent<Text>();
                levelName.text = level.name;

                if (SaveLoad.savegame.starsAchieved < level.minStarsToUnlock)
                {
                    levelName.text = "BLOQUEADO " + levelName.text;
                }
            }

            levelNumber++;
        }
    }

    public void closeLevelSelector()
    {
        levelSelector.enabled = false;
        foreach (GameObject levelBox in levelBoxes)
        {
            levelBox.GetComponent<Canvas>().enabled = false;
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
