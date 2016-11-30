using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Savegame
{

    public static Savegame current;
    public List<StadiumSavedData> stadiumsSavedData = new List<StadiumSavedData>();
    public int starsAchieved;
    public int timesDied;

    public Savegame()
    {
        starsAchieved = 0;
        timesDied = 0;
        //stadiumsSavedData = new List<StadiumSavedData>();
    }

    public void updateTotalStarsAchieved()
    {
        starsAchieved = 0;
        foreach (StadiumSavedData ssd in stadiumsSavedData)
        {
            foreach (LevelSavedData lsd in ssd.levelSavedData)
            {
                if (lsd.firstStarAchieved)
                {
                    starsAchieved++;
                }
                if (lsd.secondStarAchieved)
                {
                    starsAchieved++;
                }
                if (lsd.thirdStarAchieved)
                {
                    starsAchieved++;
                }
            }
        }
    }
}