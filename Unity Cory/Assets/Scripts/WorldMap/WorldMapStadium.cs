using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorldMapStadium : MonoBehaviour
{

    public int stadiumNumber;
    public Canvas levelSelector;
    private List<Level> stadiumLevels;



    private List<GameObject> levelBoxes;

    // Use this for initialization
    void Start()
    {
        levelSelector = levelSelector.GetComponent<Canvas>();
        levelSelector.enabled = false;

        levelBoxes = new List<GameObject>();
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level1").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level2").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level3").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level4").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level5").gameObject);
        levelBoxes.Add(levelSelector.transform.Find("BackgroundLevelSelector").Find("Level6").gameObject);
        foreach (GameObject levelBox in levelBoxes)
        {
            levelBox.GetComponent<Canvas>().enabled = false;
        }
    }

    public void changeScene(string sceneName, Level actualLevel, Stadium actualStadium)
    {
        Game.setCurrentStadium(actualStadium);
        Game.setCurrentLevel(actualLevel);
        SceneManager.LoadScene(sceneName);
    }

    public void OnMouseDown()
    {
        // Desactivar colliders de estadios para evitar problemas
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Estadio"))
        {
            go.GetComponent<BoxCollider>().enabled = false;
        }

        if (stadiumNumber > Game.stadiums.Count - 1) // Check object number to avoid out of range exception
        {
            // Instantiate Canvas
            levelSelector.enabled = true;

            if (!levelSelector.GetComponent<LevelSelector>().getVisible())
            {
                levelSelector.GetComponent<LevelSelector>().setVisible(true);
            }

            // Change title of stadium
            Text stadiumName = levelSelector.transform.Find("BackgroundLevelSelector").FindChild("StadiumName").gameObject.GetComponent<Text>();
            stadiumName.text = "Error when loading stadium";
        }
        else
        {
            Stadium stadium = Game.stadiums[stadiumNumber];
            // Instantiate Canvas
            levelSelector.enabled = true;
            if (!levelSelector.GetComponent<LevelSelector>().getVisible())
            {
                levelSelector.GetComponent<LevelSelector>().setVisible(true);
            }

            // Change title of stadium
            Text stadiumName = levelSelector.transform.Find("BackgroundLevelSelector").FindChild("StadiumName").gameObject.GetComponent<Text>();
            stadiumName.text = stadium.name;


            //GameObject levelBox = levelSelector.transform.Find("BackgroundLevelSelector").FindChild("LevelBox").gameObject;
            int levelNumber = 0;
            foreach (Level level in stadium.levels)
            {
                GameObject currentLevelBox = levelBoxes[levelNumber];
                if (levelNumber <= levelBoxes.Count - 1)
                {
                    currentLevelBox.GetComponent<Canvas>().enabled = true;
                    string sceneName = stadium.sceneName;
                    Level actualLevel = level;
                    Debug.Log(actualLevel.name);
                    currentLevelBox.GetComponent<Button>().onClick.AddListener(() => changeScene(sceneName, actualLevel, stadium));

                    Image levelPreviewImage = currentLevelBox.transform.FindChild("LevelImage").gameObject.GetComponent<Image>();
                    levelPreviewImage.sprite = Resources.Load<Sprite>("LevelPreviewImages/" + level.previewImagePath) as Sprite;

                    // Load from Savegame how many Stars has the player achieved
                    Image firstStar = currentLevelBox.transform.FindChild("FirstStar").gameObject.GetComponent<Image>();
                    firstStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
                    if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].firstStarAchieved)
                    {
                        firstStar.color = Color.grey;
                    } else
                    {
                        firstStar.color = Color.white;
                    }
                    Image secondStar = currentLevelBox.transform.FindChild("SecondStar").gameObject.GetComponent<Image>();
                    secondStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
                    if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].secondStarAchieved)
                    {
                        secondStar.color = Color.grey;
                    }
                    else
                    {
                        secondStar.color = Color.white;
                    }
                    Image thirdStar = currentLevelBox.transform.FindChild("ThirdStar").gameObject.GetComponent<Image>();
                    thirdStar.sprite = Resources.Load<Sprite>("LevelPreviewImages/star") as Sprite;
                    if (!SaveLoad.savegame.stadiumsSavedData[stadium.index].levelSavedData[level.index].thirdStarAchieved)
                    {
                        thirdStar.color = Color.grey;
                    }
                    else
                    {
                        thirdStar.color = Color.white;
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
    }

    public void closeLevelSelector()
    {
        levelSelector.enabled = false;
        foreach (GameObject levelBox in levelBoxes)
        {
            levelBox.GetComponent<Canvas>().enabled = false;
            levelBox.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (levelSelector.GetComponent<LevelSelector>().getVisible())
        {
            levelSelector.GetComponent<LevelSelector>().setVisible(false);
        }

        // Activar de nuevo colliders de estadios para poder seleccionarlos
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Estadio"))
        {
            go.GetComponent<BoxCollider>().enabled = true;
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
