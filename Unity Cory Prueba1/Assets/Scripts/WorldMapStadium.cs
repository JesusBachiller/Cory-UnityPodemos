using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class WorldMapStadium : MonoBehaviour {

    private const int BOXES_PER_ROW = 3;

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

        StadiumContainer sc = StadiumContainer.Load();
        if(stadiumNumber <= sc.stadiums.Count - 1) // Check object number to avoid out of range exception
        {
            stadium = sc.stadiums[stadiumNumber];
            string stadiumLevelsPath = stadium.xmlLevelsPath;
            LevelContainer lc = LevelContainer.Load(stadiumLevelsPath);
            stadiumLevels = lc.levels;
        }
        
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
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
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

                /*Image levelPreviewImage = currentLevelBox.transform.FindChild("LevelImage").gameObject.GetComponent<Image>();
                levelPreviewImage.sprite = Resources.Load<Sprite>("LevelPreviewImages/" + level.previewImagePath) as Sprite;*/


                GameObject levelPreviewImage = currentLevelBox.transform.FindChild("LevelImage").gameObject;
                Sprite levelSprite = new Sprite();
                SpriteRenderer renderer = levelPreviewImage.AddComponent<SpriteRenderer>();
                renderer.sprite = Resources.Load("LevelPreviewImages/" + level.previewImagePath, typeof(Sprite)) as Sprite;

                // Load from Savegame how many Stars has the player achieved
                Image firstStar = currentLevelBox.transform.FindChild("FirstStar").gameObject.GetComponent<Image>();
                /*if (firstStar is not achieved){
                    firstStar.color = Color.gray;
                }*/
                Image secondStar = currentLevelBox.transform.FindChild("SecondStar").gameObject.GetComponent<Image>();
                /*if (secondStar is not achieved){
                    secondStar.color = Color.gray;
                }*/
                Image thirdStar = currentLevelBox.transform.FindChild("ThirdStar").gameObject.GetComponent<Image>();
                /*if (thirdStar is not achieved){
                    thirdStar.color = Color.gray;
                }*/

                Text levelName = currentLevelBox.transform.FindChild("LevelName").gameObject.GetComponent<Text>();
                levelName.text = level.name;
            }

            levelNumber++;
        }
    }
    
}
