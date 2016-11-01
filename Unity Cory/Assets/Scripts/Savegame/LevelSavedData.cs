using UnityEngine;
using System.Collections;

[System.Serializable]
public class LevelSavedData {
    
    public int maxScore;
    public int fastestTime;
    public bool firstStarAchieved;
    public bool secondStarAchieved;
    public bool thirdStarAchieved;


    public LevelSavedData()
    {
        maxScore = 0;
        fastestTime = 0;
        firstStarAchieved = false;
        secondStarAchieved = false;
        thirdStarAchieved = false;
    }
}
