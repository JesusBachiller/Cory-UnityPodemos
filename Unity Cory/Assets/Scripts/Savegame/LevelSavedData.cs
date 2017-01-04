using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class LevelSavedData {

    public List<int> scores;
    public int maxScore;
    public int fastestTime;
    public bool firstStarAchieved;
    public bool secondStarAchieved;
    public bool thirdStarAchieved;
    public bool completed;


    public LevelSavedData()
    {
        scores = new List<int>();
        maxScore = 0;
        fastestTime = 0;
        firstStarAchieved = false;
        secondStarAchieved = false;
        thirdStarAchieved = false;
        completed = false;
    }
}
